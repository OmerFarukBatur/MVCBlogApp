using Microsoft.EntityFrameworkCore;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Features.Commands.YoneticiIslemleri.AdminCreate;
using MVCBlogApp.Application.Features.Queries.YoneticiIslemleri.AdminRoleList;
using MVCBlogApp.Application.Features.Queries.YoneticiIslemleri.AllAdmin;
using MVCBlogApp.Application.Repositories.Auth;
using MVCBlogApp.Application.Repositories.User;
using MVCBlogApp.Application.ViewModels;
using MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Services
{
    public class YoneticiIslemleri : IYoneticiIslemleri
    {
        private readonly IUserReadRepository _userReadRepository;
        private readonly IUserWriteRepository _userWriteRepository;
        private readonly IAuthService _authService;
        private readonly IAuthReadRepository _authReadRepository;

        public YoneticiIslemleri(IUserReadRepository userReadRepository, IUserWriteRepository userWriteRepository, IAuthService authService, IAuthReadRepository authReadRepository)
        {
            _userReadRepository = userReadRepository;
            _userWriteRepository = userWriteRepository;
            _authService = authService;
            _authReadRepository = authReadRepository;
        }

        public async Task<AdminRoleListQueryResponse> AdminListRoleAsync()
        {
            List<Auth> auths = await _authReadRepository.GetAll(false).ToListAsync();
            return new()
            {
                Auths = auths
            };
        }

        public async Task<AllAdminQueryResponse> AllAdminAsync()
        {
            List<AllAdmins> admins = await _userReadRepository.GetAll().Include(a => a.Auth).Select(x => new AllAdmins {
                Id = x.ID,
                UserName = x.UserName,
                AuthName = x.Auth.AuthName,
                CreateDate = x.CreateDate,
                CreateUserID = x.CreateUserID,
                ModifiedDate = x.ModifiedDate,
                ModifiedUserID = x.ModifiedUserID,
                IsActive = x.IsActive,
                Email = x.Email
            }).ToListAsync();

            return new() 
            { 
                AllAdmins = admins 
            };
        }

        public async Task<AdminCreateCommandResponse> CreateAdminAsync(AdminCreateCommandRequest request)
        {
            List<User> users = await _userReadRepository.GetWhere(u => u.Email == request.Email || u.UserName== request.UserName).ToListAsync();

            if (users.Count > 0)
            {
                return new AdminCreateCommandResponse() 
                {
                    Message = "Bu bilgilere sahip yönetici kayıtlıdır.",
                    Status = false
                };
            }
            else
            {
                (byte[] passwordSalt,byte[] passwordHash) = _authService.CreatePasswordHash(request.Password);
                User user = new();
                user.Email = request.Email;
                user.UserName = request.UserName;
                user.AuthID = request.AuthID;
                user.CreateUserID = request.CreateUserID != null ? request.CreateUserID : null;
                user.CreateDate = DateTime.Now;
                user.IsActive = true;
                user.PasswordSalt = passwordSalt;
                user.PasswordHash = passwordHash;

                await _userWriteRepository.AddAsync(user);
                await _userWriteRepository.SaveAsync();

                return new AdminCreateCommandResponse() 
                { 
                    Message = "Yönetici başarıyla kayıt edilmiştir.",
                    Status = true
                };
            }
        }
    }
}
