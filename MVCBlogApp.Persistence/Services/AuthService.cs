using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Features.Commands.Home.CreateUser;
using MVCBlogApp.Application.Repositories.Members;
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

        public AuthService(IMembersReadRepository membersReadRepository, IMembersWriteRepository membersWriteRepository)
        {
            _membersReadRepository = membersReadRepository;
            _membersWriteRepository = membersWriteRepository;
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
                (byte[] passwordSalt, byte[] passwordHash) = CreatePasswordHash(request.Password);
                Members newmember = new() 
                { 
                    NameSurname= request.Name.Trim().ToUpper() + request.Surname.Trim().ToUpper(),
                    EMail = request.Email,
                    CreateDate = DateTime.Now,
                    PasswordSalt = passwordSalt,
                    PasswordHash = passwordHash,
                    IsActive = true,
                    MembersAuthID = 1
                };
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
