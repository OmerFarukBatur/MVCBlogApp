using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Features.Commands.Home.CreateUser;
using MVCBlogApp.Application.Repositories.Members;
using MVCBlogApp.Application.Repositories.MembersAuth;
using MVCBlogApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCBlogApp.Persistence.Services
{
    public class AuthService : IAuthService
    {
        private readonly IMembersReadRepository _membersReadRepository;
        private readonly IMembersWriteRepository _membersWriteRepository;
        private readonly IMembersAuthReadRepository _membersAuthReadRepository;

        public AuthService(IMembersReadRepository membersReadRepository, IMembersWriteRepository membersWriteRepository, IMembersAuthReadRepository membersAuthReadRepository)
        {
            _membersReadRepository = membersReadRepository;
            _membersWriteRepository = membersWriteRepository;
            _membersAuthReadRepository = membersAuthReadRepository;
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

        public async Task<CreateUserCommandResponse> CreateUserAsync(CreateUserCommandRequest request)
        {
            var member = await _membersReadRepository.GetWhere(a => a.EMail == request.Email).ToListAsync();

            if (member.Count > 0)
            {
                return new CreateUserCommandResponse()
                {
                    Message = "Bu bilgilere sahip bir kullanıcı bulunmaktadır."
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
                    NameSurname= request.Name.Trim().ToUpper() + request.Surname.Trim().ToUpper(),
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
                    Message= "Kullanıcı başarıyla kayıt edilmiştir." 
                };
            }
        }
    }
}
