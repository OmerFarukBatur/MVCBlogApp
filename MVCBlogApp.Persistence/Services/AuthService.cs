﻿using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Features.Commands.Home.CreateUser;
using MVCBlogApp.Application.Features.Commands.Home.PasswordReset;
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
        private readonly IUserWriteRepository _userWriteRepository;
        private readonly IMailService _mailService;

        public AuthService(IMembersReadRepository membersReadRepository, IMembersWriteRepository membersWriteRepository, IMembersAuthReadRepository membersAuthReadRepository, IUserReadRepository userReadRepository, IMailService mailService, IUserWriteRepository userWriteRepository)
        {
            _membersReadRepository = membersReadRepository;
            _membersWriteRepository = membersWriteRepository;
            _membersAuthReadRepository = membersAuthReadRepository;
            _userReadRepository = userReadRepository;
            _mailService = mailService;
            _userWriteRepository = userWriteRepository;
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

                await _mailService.SendMailAsync(newmember.EMail, newmember.NameSurname, request.Password);

                return new CreateUserCommandResponse()
                {
                    Message = "Kullanıcı başarıyla kayıt edilmiştir.",
                    StatusCode = true
                };
            }
        }

        public async Task<LoginQueryResponse> Login(LoginQueryRequest request)
        {
            Members member = await _membersReadRepository.GetWhere(a => a.EMail == request.Email && a.IsActive == true).Include(s => s.MembersAuth).FirstOrDefaultAsync();
            User user = await _userReadRepository.GetWhere(u => u.Email == request.Email && u.IsActive == true).Include(s => s.Auth).FirstOrDefaultAsync();

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
                if (VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
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

        public async Task<PasswordResetCommandResponse> ByIdUserPasswordReset(PasswordResetCommandRequest request)
        {
            Members member = await _membersReadRepository.GetWhere(a => a.EMail == request.Email && a.IsActive == true).Include(s => s.MembersAuth).FirstOrDefaultAsync();
            User user = await _userReadRepository.GetWhere(u => u.Email == request.Email && u.IsActive == true).Include(s => s.Auth).FirstOrDefaultAsync();

            Random random = new Random();
            long password = random.NextInt64(100000,10000000000);

            if (member != null)
            {
                (byte[] passwordSalt, byte[] passwordHash) = CreatePasswordHash(password.ToString());

                member.PasswordSalt = passwordSalt;
                member.PasswordHash = passwordHash;

                _membersWriteRepository.Update(member);
                await _membersWriteRepository.SaveAsync();
                await _mailService.SendMailAsync(request.Email,member.NameSurname,password.ToString());

                return new()
                {
                    Status = true
                };
            }
            else if (user != null)
            {
                (byte[] passwordSalt, byte[] passwordHash) = CreatePasswordHash(password.ToString());

                user.PasswordSalt = passwordSalt;
                user.PasswordHash = passwordHash;

                _userWriteRepository.Update(user);
                await _userWriteRepository.SaveAsync();
                await _mailService.SendMailAsync(request.Email, user.UserName, password.ToString());

                return new()
                {
                    Status = true
                };
            }
            else
            {
                return new() 
                {
                    Status = true
                };
            }
        }
        
    }
}