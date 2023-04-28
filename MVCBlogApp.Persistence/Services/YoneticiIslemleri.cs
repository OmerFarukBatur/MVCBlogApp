using MediatR;
using Microsoft.EntityFrameworkCore;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Abstractions.Storage;
using MVCBlogApp.Application.Features.Commands.YoneticiIslemleri.AdminByIdRemove;
using MVCBlogApp.Application.Features.Commands.YoneticiIslemleri.AdminCreate;
using MVCBlogApp.Application.Features.Commands.YoneticiIslemleri.AdminUpdate;
using MVCBlogApp.Application.Features.Commands.YoneticiIslemleri.TK.TKBiographyCreate;
using MVCBlogApp.Application.Features.Commands.YoneticiIslemleri.TK.TKBiographyDelete;
using MVCBlogApp.Application.Features.Commands.YoneticiIslemleri.TK.TKBiographyUpdate;
using MVCBlogApp.Application.Features.Queries.YoneticiIslemleri.AdminRoleList;
using MVCBlogApp.Application.Features.Queries.YoneticiIslemleri.AllAdmin;
using MVCBlogApp.Application.Features.Queries.YoneticiIslemleri.GetByIdAdmin;
using MVCBlogApp.Application.Features.Queries.YoneticiIslemleri.TK.GetAllTKBiography;
using MVCBlogApp.Application.Features.Queries.YoneticiIslemleri.TK.GetByIdTKBiography;
using MVCBlogApp.Application.Features.Queries.YoneticiIslemleri.TK.GetTKBiographyCreateItems;
using MVCBlogApp.Application.Repositories.Auth;
using MVCBlogApp.Application.Repositories.Languages;
using MVCBlogApp.Application.Repositories.Status;
using MVCBlogApp.Application.Repositories.TaylanK;
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
        private readonly ITaylanKReadRepository _waylanKReadRepository;
        private readonly ITaylanKWriteRepository _waylanKWriteRepository;
        private readonly IStatusReadRepository _statusReadRepository;
        private readonly ILanguagesReadRepository _languagesReadRepository;
        private readonly IStorageService _storageService;

        public YoneticiIslemleri(
            IUserReadRepository userReadRepository,
            IUserWriteRepository userWriteRepository,
            IAuthService authService,
            IAuthReadRepository authReadRepository,
            IMailService mailService,
            ITaylanKReadRepository waylanKReadRepository,
            ITaylanKWriteRepository waylanKWriteRepository,
            IStatusReadRepository statusReadRepository,
            ILanguagesReadRepository languagesReadRepository,
            IStorageService storageService)
        {
            _userReadRepository = userReadRepository;
            _userWriteRepository = userWriteRepository;
            _authService = authService;
            _authReadRepository = authReadRepository;
            _mailService = mailService;
            _waylanKReadRepository = waylanKReadRepository;
            _waylanKWriteRepository = waylanKWriteRepository;
            _statusReadRepository = statusReadRepository;
            _languagesReadRepository = languagesReadRepository;
            _storageService = storageService;
        }

        #region Admin

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
                .Join(_authReadRepository.GetAll(), us => us.AuthId, au => au.Id, (us, au) => new { us, au })
                .Select(x => new AllAdmins
                {
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
            List<User> users = await _userReadRepository.GetWhere(u => u.Email == request.Email || u.Username == request.UserName).ToListAsync();

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
                (byte[] passwordSalt, byte[] passwordHash) = _authService.CreatePasswordHash(request.Password);
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
                    Auths = auths,
                    Email = user.Email,
                    UserName = user.Username,
                    Id = user.Id,
                    IsActive = user.IsActive,
                    AuthId = user.AuthId,
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
                byte[] passwordSalt, passwordHash;

                if (request.Password != null)
                {
                    (passwordSalt, passwordHash) = _authService.CreatePasswordHash(request.Password);
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
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
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

        #endregion

        #region TK

        public async Task<GetTKBiographyCreateItemsQueryResponse> GetTKBiographyCreateItemsAsync()
        {
            List<VM_Language> vM_Languages = await _languagesReadRepository
                .GetAll()
                .Select(x => new VM_Language
                {
                    Id = x.Id,
                    Language = x.Language
                }).ToListAsync();

            List<AllStatus> allStatus = await _statusReadRepository
                .GetAll()
                .Select(x => new AllStatus
                {
                    Id = x.Id,
                    StatusName = x.StatusName
                }).ToListAsync();

            return new()
            {
                Languages = vM_Languages,
                Statuses = allStatus
            };
        }

        public async Task<GetAllTKBiographyQueryResponse> GetAllTKBiographyAsync()
        {
            List<VM_TaylanK> vM_TaylanKs = await _waylanKReadRepository.GetAll()
                .Join(_languagesReadRepository.GetAll(), ta => ta.LangId, lg => lg.Id, (ta, lg) => new { ta, lg })
                .Join(_statusReadRepository.GetAll(), tay => tay.ta.StatusId, st => st.Id, (tay, st) => new { tay, st })
                .Select(x => new VM_TaylanK
                {
                    Id = x.tay.ta.Id,
                    Adress = x.tay.ta.Adress,
                    CompanyName = x.tay.ta.CompanyName,
                    Email1 = x.tay.ta.Email1,
                    Phone1 = x.tay.ta.Phone1,
                    CreateDate = x.tay.ta.CreateDate,
                    Language = x.tay.lg.Language,
                    StatusName = x.st.StatusName
                }).ToListAsync();

            return new()
            {
                TaylanKs = vM_TaylanKs
            };
        }

        public async Task<TKBiographyCreateCommandResponse> TKBiographyCreateAsync(TKBiographyCreateCommandRequest request)
        {
            var check = await _waylanKReadRepository.GetWhere(x => x.StatusId == 1).ToListAsync();

            if (check.Count() > 1)
            {
                request.StatusId = 2;
            }

            List<(string fileName, string pathOrContainerName)> result = await _storageService.UploadAsync("taylaK-logo-files", request.FormFile);

            TaylanK taylanK = new()
            {
                About = request.About,
                Adress = request.Adress,
                Bio = request.Bio,
                CompanyName = request.CompanyName,
                CreateDate = DateTime.Now,
                Email1 = request.Email1,
                Email2 = request.Email2,
                Phone1 = request.Phone1,
                Facebook = request.Facebook,
                Fax = request.Fax,
                GoogleMap = request.GoogleMap,
                Instagram = request.Instagram,
                LangId = request.LangId,
                Metadescription = request.Metadescription,
                Metakey = request.Metakey,
                Metatitle = request.Metatitle,
                Phone2 = request.Phone2,
                Pinterest = request.Pinterest,
                StatusId = 1,
                Twitter = request.Twitter,
                UserId = request.UserId > 0 ? request.UserId : null,
                Logo = @"~\Upload\" + result[0].pathOrContainerName
            };

            await _waylanKWriteRepository.AddAsync(taylanK);
            await _waylanKWriteRepository.SaveAsync();

            return new()
            {
                Message = "Kayıt işlemi başarıyla yapılmıştır.",
                State = true
            };
        }

        public async Task<GetByIdTKBiographyQueryResponse> GetByIdTKBiographyAsync(int id)
        {
            VM_TaylanK? vM_TaylanK = await _waylanKReadRepository.GetWhere(x => x.Id == id)
                .Select(x => new VM_TaylanK
                {
                    Id = x.Id,
                    About = x.About,
                    Adress = x.Adress,
                    Bio = x.Bio,
                    CompanyName = x.CompanyName,
                    Email1 = x.Email1,
                    Email2 = x.Email2,
                    Facebook = x.Facebook,
                    Fax = x.Fax,
                    GoogleMap = x.GoogleMap,
                    Instagram = x.Instagram,
                    LangId = x.LangId,
                    Metadescription = x.Metadescription,
                    Metakey = x.Metakey,
                    Metatitle = x.Metatitle,
                    Phone1 = x.Phone1,
                    Phone2 = x.Phone2,
                    Pinterest = x.Pinterest,
                    StatusId = x.StatusId,
                    Twitter = x.Twitter
                }).FirstOrDefaultAsync();

            if (vM_TaylanK != null)
            {
                List<VM_Language> vM_Languages = await _languagesReadRepository
                .GetAll()
                .Select(x => new VM_Language
                {
                    Id = x.Id,
                    Language = x.Language
                }).ToListAsync();

                List<AllStatus> allStatus = await _statusReadRepository
                    .GetAll()
                    .Select(x => new AllStatus
                    {
                        Id = x.Id,
                        StatusName = x.StatusName
                    }).ToListAsync();

                return new()
                {
                    Languages = vM_Languages,
                    Statuses = allStatus,
                    TaylanK = vM_TaylanK,
                    Message = null,
                    State = true
                };
            }
            else
            {
                return new()
                {
                    Languages = null,
                    Statuses = null,
                    TaylanK = null,
                    Message = "Kayıt bulunamamıştır.",
                    State = false
                };
            }
        }

        public async Task<TKBiographyUpdateCommandResponse> TKBiographyUpdateAsync(TKBiographyUpdateCommandRequest request)
        {
            TaylanK taylanK = await _waylanKReadRepository.GetByIdAsync(request.Id);

            if (taylanK != null)
            {
                taylanK.About = request.About;
                taylanK.Adress = request.Adress;
                taylanK.Bio = request.Bio;
                taylanK.CompanyName = request.CompanyName;
                taylanK.Email1 = request.Email1;
                taylanK.Email2 = request.Email2;
                taylanK.Phone1 = request.Phone1;
                taylanK.Facebook = request.Facebook;
                taylanK.Fax = request.Fax;
                taylanK.GoogleMap = request.GoogleMap;
                taylanK.Instagram = request.Instagram;
                taylanK.LangId = request.LangId;
                taylanK.Metadescription = request.Metadescription;
                taylanK.Metakey = request.Metakey;
                taylanK.Metatitle = request.Metatitle;
                taylanK.Phone2 = request.Phone2;
                taylanK.Pinterest = request.Pinterest;
                taylanK.Twitter = request.Twitter;
                taylanK.StatusId = 1;

                if (request.FormFile != null)
                {
                    List<(string fileName, string pathOrContainerName)> result = await _storageService.UploadAsync("taylaK-logo-files", request.FormFile);
                    taylanK.Logo = @"~\Upload\" + result[0].pathOrContainerName;
                }

                var check = await _waylanKReadRepository.GetWhere(x => x.StatusId == 1).ToListAsync();

                if (check.Count() > 1)
                {
                    taylanK.StatusId = 2;
                }

                _waylanKWriteRepository.Update(taylanK);
                await _waylanKWriteRepository.SaveAsync();

                return new()
                {
                    Message = "Güncelleme işlemi başarıyla yapılmıştır.",
                    State = true
                };
            }
            else
            {
                return new()
                {
                    Message = "Kayıt bulunamamıştır.",
                    State = false
                };
            }
        }

        public async Task<TKBiographyDeleteCommandResponse> TKBiographyDeleteAsync(int id)
        {
            TaylanK taylanK = await _waylanKReadRepository.GetByIdAsync(id);

            if (taylanK != null)
            {
                int statusId = await _statusReadRepository.GetWhere(x => x.StatusName == "Pasif").Select(x => x.Id).FirstAsync();
                taylanK.StatusId = statusId;

                _waylanKWriteRepository.Update(taylanK);
                await _waylanKWriteRepository.SaveAsync();

                return new()
                {
                    Message = null,
                    State = true
                };
            }
            else
            {
                return new()
                {
                    Message = "Kayıt bulunamamıştır.",
                    State = false
                };
            }
        }


        #endregion
    }
}
