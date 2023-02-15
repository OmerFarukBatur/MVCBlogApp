using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Features.Commands.Home.CreateUser;
using MVCBlogApp.Application.Features.Queries.Home.Login;
using MVCBlogApp.Application.Repositories.Members;
using MVCBlogApp.Application.Repositories.MembersAuth;
using MVCBlogApp.Application.Repositories.User;
using MVCBlogApp.Domain.Entities;
using System.Text;

namespace MVCBlogApp.Persistence.Services
{
    public class AuthService : IAuthService
    {
        private readonly IMembersReadRepository _membersReadRepository;
        private readonly IMembersWriteRepository _membersWriteRepository;
        private readonly IMembersAuthReadRepository _membersAuthReadRepository;
        private readonly IUserReadRepository _userReadRepository;

        public AuthService(IMembersReadRepository membersReadRepository, IMembersWriteRepository membersWriteRepository, IMembersAuthReadRepository membersAuthReadRepository, IUserReadRepository userReadRepository)
        {
            _membersReadRepository = membersReadRepository;
            _membersWriteRepository = membersWriteRepository;
            _membersAuthReadRepository = membersAuthReadRepository;
            _userReadRepository = userReadRepository;
        }

        public (byte[] passwordSalt, byte[] passwordHash) CreatePasswordHash(string password)
        {
            var hmac = new System.Security.Cryptography.HMACSHA512();

            return new()
            {
                passwordSalt = hmac.Key,
                passwordHash = hmac.ComputeHash(Encoding.UTF32.GetBytes(password))
            };
        }

        public bool VerifyPasswordHash(string Password, byte[] userpasswordHash, byte[] userpasswordSalt)
        {

            using (var hmac = new System.Security.Cryptography.HMACSHA512(userpasswordSalt))
            {
                var ComputeHash = hmac.ComputeHash(Encoding.UTF32.GetBytes(Password));
                for (int i = 0; i < ComputeHash.Length; i++)
                {
                    if (ComputeHash[i] != userpasswordHash[i])
                    {
                        return false;
                    }
                }
                return true;

            }
        }
        public async Task<CreateUserCommandResponse> CreateUserAsync(CreateUserCommandRequest request)
        {
            var member = await _membersReadRepository.GetWhere(a => a.EMail == request.Email).ToListAsync();

            if (member.Count > 0)
            {
                return new CreateUserCommandResponse()
                {
                    Message = "Bu bilgilere sahip bir kullanıcı bulunmaktadır.",
                    StatusCode = false
                };
            }
            else
            {
                var authId = await _membersAuthReadRepository.GetWhere(x => x.IsActive == true).Select(a => new
                {
                    a.ID
                }).FirstOrDefaultAsync();


                (byte[] passwordSalt, byte[] passwordHash) = CreatePasswordHash(request.Password);
                Members newmember = new()
                {
                    NameSurname = request.Name.Trim().ToUpper() + request.Surname.Trim().ToUpper(),
                    EMail = request.Email,
                    CreateDate = DateTime.Now,
                    PasswordSalt = passwordSalt,
                    PasswordHash = passwordHash,
                    IsActive = true,
                    Phone = request.PhoneNumber
                };


                if (authId != null)
                {
                    newmember.MembersAuthID = authId.ID;
                }

                await _membersWriteRepository.AddAsync(newmember);
                await _membersWriteRepository.SaveAsync();

                return new CreateUserCommandResponse()
                {
                    Message = "Kullanıcı başarıyla kayıt edilmiştir.",
                    StatusCode = true
                };
            }
        }

        public async Task<LoginQueryResponse> Login(LoginQueryRequest request)
        {
            Members member = await _membersReadRepository.GetWhere(a => a.EMail == request.Email).Include(s => s.MembersAuth).FirstOrDefaultAsync();
            User user = await _userReadRepository.GetWhere(u => u.Email == request.Email).Include(s => s.Auth).FirstOrDefaultAsync();

            if (member != null)
            {
                if (VerifyPasswordHash(request.Password, member.PasswordHash, member.PasswordSalt))
                {
                    return new LoginQueryResponse()
                    {
                        Email = member.EMail,
                        Id = member.ID,
                        AuthRole = member.MembersAuth != null ? member.MembersAuth.MembersAuthName : null,
                        Role = false
                    };
                }
                return new LoginQueryResponse() 
                { 
                    Message = "Girilen Şifre veya Email Yanlış" 
                };
            }
            else if (user != null)
            {
                if (VerifyPasswordHash(request.Password, member.PasswordHash, member.PasswordSalt))
                {
                    return new LoginQueryResponse()
                    {
                        Email = user.Email,
                        Id = user.ID,
                        AuthRole = user.Auth != null ? user.Auth.AuthName : null,
                        Role = true
                    };
                }
                return new LoginQueryResponse()
                {
                    Message = "Girilen Şifre veya Email Yanlış"
                };
            }
            else
            {
                return new LoginQueryResponse()
                {
                    Message = "Girilen Şifre veya Email Yanlış"
                };
            }
        }
    }
}
