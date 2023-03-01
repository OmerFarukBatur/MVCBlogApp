using Microsoft.EntityFrameworkCore;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Features.Commands.YoneticiIslemleri.AdminByIdRemove;
using MVCBlogApp.Application.Features.Commands.YoneticiIslemleri.AdminCreate;
using MVCBlogApp.Application.Features.Commands.YoneticiIslemleri.AdminUpdate;
using MVCBlogApp.Application.Features.Queries.YoneticiIslemleri.AdminRoleList;
using MVCBlogApp.Application.Features.Queries.YoneticiIslemleri.AllAdmin;
using MVCBlogApp.Application.Features.Queries.YoneticiIslemleri.GetByIdAdmin;
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
        private readonly IMailService _mailService;

        public YoneticiIslemleri(IUserReadRepository userReadRepository, IUserWriteRepository userWriteRepository, IAuthService authService, IAuthReadRepository authReadRepository, IMailService mailService)
        {
            _userReadRepository = userReadRepository;
            _userWriteRepository = userWriteRepository;
            _authService = authService;
            _authReadRepository = authReadRepository;
            _mailService = mailService;
        }

        public async Task<AdminByIdRemoveCommandResponse> AdminDeleteAsync(AdminByIdRemoveCommandRequest request)
        {
            User user = await _userReadRepository.GetByIdAsync(request.Id);

            if (user != null)
            {
                user.IsActive = false;
                _userWriteRepository.Update(user);
                await _userWriteRepository.SaveAsync();
                return new()
                {
                    Message = "Kayıt başarıyla silinmiştir.",
                    State = true
                };
            }
            else
            {
                return new()
                {
                    Message = "Bu bilgilere ait kullanıcı bulunmamaktadır.",
                    State = false
                };
            }
            
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
            List<AllAdmins> admins = await _userReadRepository.GetAll()
                .Join(_authReadRepository.GetAll(),us=> us.AuthId, au=> au.Id, (us,au)=> new {us,au})
                .Select(x => new AllAdmins {
                Id = x.us.Id,
                UserName = x.us.Username,
                AuthName = x.au.AuthName,
                CreateDate = (DateTime)x.us.CreateDate,
                CreateUserID = x.us.CreateUserId,
                ModifiedDate = x.us.ModifiedDate,
                ModifiedUserID = x.us.ModifiedUserId,
                IsActive = (bool)x.us.IsActive,
                Email = x.us.Email
            }).ToListAsync();

            return new() 
            { 
                AllAdmins = admins 
            };
        }

        public async Task<AdminCreateCommandResponse> CreateAdminAsync(AdminCreateCommandRequest request)
        {
            List<User> users = await _userReadRepository.GetWhere(u => u.Email == request.Email || u.Username== request.UserName).ToListAsync();

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
                user.Username = request.UserName;
                user.AuthId = request.AuthID;
                user.CreateUserId = request.CreateUserID != null ? request.CreateUserID : null;
                user.CreateDate = DateTime.Now;
                user.IsActive = true;
                user.PasswordSalt = passwordSalt;
                user.PasswordHash = passwordHash;

                await _userWriteRepository.AddAsync(user);
                await _userWriteRepository.SaveAsync();

                //await _mailService.SendMailAsync(user.Email,user.Username,request.Password);

                return new AdminCreateCommandResponse() 
                { 
                    Message = "Yönetici başarıyla kayıt edilmiştir.",
                    Status = true
                };
            }
        }

        public async Task<GetByIdAdminQueryResponse> GetByIdAdminAsync(int id)
        {
            User user = await _userReadRepository.GetByIdAsync(id);
            if (user != null)
            {
                List<Auth> auths = await _authReadRepository.GetAll(false).ToListAsync();
                return new GetByIdAdminQueryResponse() 
                {
                    Auths= auths,
                    Email = user.Email,
                    UserName = user.Username,
                    Id= user.Id,
                    IsActive = user.IsActive,
                    AuthId= user.AuthId,
                    State = true
                };
            }
            else
            {
                return new()
                {
                    Message = "Bu Id'ye ait bir admin bulunmamktadır.",
                    State = false
                };
            }
        }

        public async Task<AdminUpdateCommandResponse> UpdateAdminAsync(AdminUpdateCommandRequest request)
        {
            User user = await _userReadRepository.GetByIdAsync(request.Id);
            if (user != null)
            {
                byte[] passwordSalt , passwordHash ;

                if (request.Password != null)
                {
                    (passwordSalt,passwordHash) = _authService.CreatePasswordHash(request.Password);
                }
                else
                {
                    passwordHash = user.PasswordHash;
                    passwordSalt = user.PasswordSalt;
                }

                user.AuthId = request.AuthID > 0 ? request.AuthID : user.AuthId;
                user.Username = request.UserName;
                user.Email = request.Email;
                user.ModifiedDate = DateTime.Now;
                user.ModifiedUserId = request.ModifiedUserID;
                user.PasswordHash= passwordHash;
                user.PasswordSalt= passwordSalt; 
                user.IsActive = request.IsActive;
                
                _userWriteRepository.Update(user);
                await _userWriteRepository.SaveAsync();

                return new() 
                {
                    Message = "Kullanıcı başarılı bir şekilde güncellendi.",
                    Status = true
                };
            }
            else
            {
                return new()
                {
                    Message = "Kayıt sırasında beklenmedik bir hata oluştu.",
                    Status = false
                };
            }
        }
    }
}
