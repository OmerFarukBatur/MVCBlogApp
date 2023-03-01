using Microsoft.EntityFrameworkCore;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Features.Commands.GeneralOptions.Languages.CreateLanguage;
using MVCBlogApp.Application.Features.Commands.GeneralOptions.Languages.DeleteLanguage;
using MVCBlogApp.Application.Features.Commands.GeneralOptions.Languages.UpdateLanguage;
using MVCBlogApp.Application.Features.Commands.GeneralOptions.Navigation.NavigationCreate;
using MVCBlogApp.Application.Features.Commands.GeneralOptions.Navigation.NavigationDelete;
using MVCBlogApp.Application.Features.Commands.GeneralOptions.Navigation.NavigationUpdate;
using MVCBlogApp.Application.Features.Queries.GeneralOptions.Languages.GetAllLanguage;
using MVCBlogApp.Application.Features.Queries.GeneralOptions.Languages.GetByIdLanguage;
using MVCBlogApp.Application.Features.Queries.GeneralOptions.Navigation.GetAllNavigation;
using MVCBlogApp.Application.Features.Queries.GeneralOptions.Navigation.GetByIdNavigation;
using MVCBlogApp.Application.Features.Queries.GeneralOptions.Navigation.GetNavigationCreateItems;
using MVCBlogApp.Application.Repositories.Languages;
using MVCBlogApp.Application.Repositories.Navigation;
using MVCBlogApp.Application.ViewModels;
using MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Services
{
    public class GeneralOptionsService : IGeneralOptionsService
    {
        private readonly ILanguagesReadRepository _languagesReadRepository;
        private readonly ILanguagesWriteRepository _languagesWriteRepository;
        private readonly INavigationReadRepository _navigationReadRepository;
        private readonly INavigationWriteRepository _navigationWriteRepository;

        public GeneralOptionsService(ILanguagesReadRepository languagesReadRepository, ILanguagesWriteRepository languagesWriteRepository, INavigationReadRepository navigationReadRepository, INavigationWriteRepository navigationWriteRepository)
        {
            _languagesReadRepository = languagesReadRepository;
            _languagesWriteRepository = languagesWriteRepository;
            _navigationReadRepository = navigationReadRepository;
            _navigationWriteRepository = navigationWriteRepository;
        }

        #region Language

        public async Task<CreateLanguageCommandResponse> CreateLanguageAsync(CreateLanguageCommandRequest request)
        {
            var language = await _languagesReadRepository.GetWhere(l => l.Language.Trim().ToLower() == request.Language.Trim().ToLower() || l.Language.Trim().ToUpper() == request.Language.Trim().ToUpper()).ToListAsync();

            if (language.Count > 0)
            {
                return new()
                {
                    Message = "Bu bilgilere sahip kayıt vardır.",
                    State = false
                };
            }
            else
            {
                Languages languages = new()
                {
                    Language = request.Language,
                    IsActive = true,
                    CreateDate = DateTime.Now
                };

                await _languagesWriteRepository.AddAsync(languages);
                await _languagesWriteRepository.SaveAsync();

                return new()
                {
                    Message = "Kayıt başarıyla yapılmıştır.",
                    State = true
                };
            }
        }

        public async Task<DeleteLanguageCommandResponse> DeleteLanguageAsync(DeleteLanguageCommandRequest request)
        {
            Languages languages = await _languagesReadRepository.GetByIdAsync(request.Id);
            if (languages != null)
            {
                languages.IsActive = false;
                _languagesWriteRepository.Update(languages);
                await _languagesWriteRepository.SaveAsync();

                return new()
                {
                    Message = "İşlem başarıyla yapıldı.",
                    State = true
                };
            }
            else
            {
                return new()
                {
                    Message = "İşlem sırasında beklenmedik bir hatayla karşılaşıldı.",
                    State = false
                };
            }
        }

        public async Task<List<AllLanguage>> GetAllLanguageAsync(GetAllLanguageQueryRequest request)
        {
            List<AllLanguage> allLanguages = await _languagesReadRepository.GetAll().Select(a => new AllLanguage
            {
                Id = a.Id,
                Language = a.Language,
                IsActive = (bool)a.IsActive,
                CreatedDate = a.CreateDate
            }).ToListAsync();

            return allLanguages;
        }

        public async Task<GetByIdLanguageQueryResponse> GetByIdLanguageAsync(GetByIdLanguageQueryRequest request)
        {
            Languages language = await _languagesReadRepository.GetByIdAsync(request.Id);

            if (language != null)
            {                
                return new()
                {
                    Language = new VM_Language
                    {
                        Id = language.Id,
                        Language = language.Language,
                        IsActive = (bool)language.IsActive
                    },
                    State = true

                };
            }

            return new()
            {
                State = false
            };
        }


        public async Task<UpdateLanguageCommandResponse> UpdateLanguageAsync(UpdateLanguageCommandRequest request)
        {
            Languages languages = await _languagesReadRepository.GetByIdAsync(request.Id);
            if (languages != null)
            {
                languages.Language = request.Language;
                languages.IsActive = request.IsActive;

                _languagesWriteRepository.Update(languages);
                await _languagesWriteRepository.SaveAsync();

                return new()
                {
                    Message = "Güncellenme işlemi başarılı bir şekilde yapıldı.",
                    State = true
                };
            }
            else
            {
                return new()
                {
                    Message = "Güncellenme işlemi sırasında beklenmedik bir hata oluştu.",
                    State = false
                };
            }
        }

        #endregion

        #region Navigation

        public async Task<NavigationCreateCommandResponse> NavigationCreateAsync(NavigationCreateCommandRequest request)
        {
            var navigationList = await _navigationReadRepository.GetWhere(x => x.NavigationName.Trim().ToLower() == request.NavigationName.Trim().ToLower() || x.NavigationName.Trim().ToUpper() == request.NavigationName.Trim().ToUpper()).ToListAsync();

            if (navigationList.Count > 0)
            {
                return new()
                {
                    Message = "Bu bilgilere sahip kayıt bulunmaktadır.",
                    State = false
                };
            }
            else
            {
                Navigation navigation = new()
                {
                    ParentId = request.ParentID,
                    OrderNo = request.OrderNo,
                    IsHeader = request.IsHeader,
                    IsSubHeader = request.IsSubHeader,
                    MetaTitle = request.MetaTitle,
                    MetaKey = request.MetaKey,
                    UrlRoot = request.UrlRoot,
                    NavigationName = request.NavigationName,
                    Controller = request.Controller,
                    Action = request.Action,
                    FontAwesomeIcon = request.FontAwesomeIcon,
                    IsActive = request.IsActive,
                    LangId = request.LangID,
                    IsAdmin = request.IsAdmin,
                    CreateDate = DateTime.Now,
                    Type = 0
                };

                await _navigationWriteRepository.AddAsync(navigation);
                await _navigationWriteRepository.SaveAsync();

                return new()
                {
                    Message = "İşlem başarıyla gerçekleştirildi.",
                    State = true
                };
            }
        }

        public async Task<GetNavigationCreateItemsCommandResponse> GetNavigationCreateItemsAsync()
        {
            List<VM_Navigation> vM_Navigations = await _navigationReadRepository.GetAll().Select(x => new VM_Navigation
            {
                Id = x.Id,
                MetaTitle = x.MetaTitle,
                NavigationName = x.NavigationName
            }).ToListAsync();

            List<VM_Language> vM_Languages = await _languagesReadRepository.GetAll().Select(x => new VM_Language
            {
                Id = x.Id,
                Language = x.Language,
                IsActive = (bool)x.IsActive
            }).ToListAsync();

            return new()
            {
                Languages = vM_Languages,
                Navigations = vM_Navigations
            };
        }

        public async Task<GetAllNavigationQueryResponse> GetAllNavigationAsync()
        {
            List<VM_Navigation> vM_Navigations = await _navigationReadRepository.GetAll(false)
                .Join(_languagesReadRepository.GetAll(), na => na.LangId, la => la.Id, (na, la) => new { na, la })
                .Select(x => new VM_Navigation
                {
                    Id = x.na.Id,
                    MetaTitle = x.na.MetaTitle,
                    Action = x.na.Action,
                    Controller = x.na.Controller,
                    CreateDate = x.na.CreateDate,
                    FontAwesomeIcon = x.na.FontAwesomeIcon,
                    IsActive = x.na.IsActive,
                    IsAdmin = x.na.IsAdmin,
                    IsHeader = x.na.IsHeader,
                    IsSubHeader = x.na.IsSubHeader,
                    Language = x.la.Language,
                    MetaKey = x.na.MetaKey,
                    NavigationName = x.na.NavigationName,
                    OrderNo = x.na.OrderNo,
                    ParentId = x.na.ParentId,
                    Type = x.na.Type,
                    UrlRoot = x.na.UrlRoot,
                    LangId = x.na.LangId
                }).ToListAsync();

            return new()
            {
                AllNavigations = vM_Navigations
            };
        }

        public async Task<GetByIdNavigationQueryResponse> GetByIdNavigationAsync(GetByIdNavigationQueryRequest request)
        {
            VM_Navigation? navigation = await _navigationReadRepository
                .GetWhere(x => x.Id == request.Id)
                .Select(s => new VM_Navigation
                {
                    Id = s.Id,
                    Action = s.Action,
                    Controller = s.Controller,
                    CreateDate = s.CreateDate,
                    FontAwesomeIcon = s.FontAwesomeIcon,
                    IsActive = s.IsActive,
                    IsAdmin = s.IsAdmin,
                    IsHeader = s.IsHeader,
                    IsSubHeader = s.IsSubHeader,
                    LangId = s.LangId,
                    MetaKey = s.MetaKey,
                    MetaTitle = s.MetaTitle,
                    NavigationName = s.NavigationName,
                    OrderNo = s.OrderNo,
                    ParentId = s.ParentId,
                    Type = s.Type,
                    UrlRoot = s.UrlRoot
                }).FirstOrDefaultAsync();

            if (navigation != null)
            {
                List<VM_Language> vM_Language = await _languagesReadRepository
                    .GetAll()
                    .Select(x => new VM_Language
                    {
                        Id = x.Id,
                        IsActive = (bool)x.IsActive,
                        Language = x.Language
                    }).ToListAsync();

                List<VM_Navigation> vM_Navigations = await _navigationReadRepository
                    .GetAll()
                    .Select(a => new VM_Navigation
                    {
                        Id = a.Id,
                        NavigationName = a.NavigationName
                    }).ToListAsync();


                return new()
                {
                    Languages = vM_Language,
                    Navigation = navigation,
                    Navigations = vM_Navigations,
                    State = true
                };
            }
            else
            {
                return new()
                {
                    State = false
                };
            }

        }

        public async Task<NavigationUpdateCommandResponse> NavigationUpdateAsync(NavigationUpdateCommandRequest request)
        {
            Navigation navigation = await _navigationReadRepository.GetByIdAsync(request.Id);

            if (navigation != null)
            {
                navigation.Action = request.Action;
                navigation.NavigationName = request.NavigationName;
                navigation.OrderNo = request.OrderNo;
                navigation.ParentId = request.ParentId;
                navigation.IsHeader = request.IsHeader;
                navigation.IsSubHeader = request.IsSubHeader;
                navigation.Controller = request.Controller;
                navigation.FontAwesomeIcon = request.FontAwesomeIcon;
                navigation.IsActive = request.IsActive;
                navigation.IsAdmin = request.IsAdmin;
                navigation.LangId = request.LangId;
                navigation.MetaKey = request.MetaKey;
                navigation.MetaTitle = request.MetaTitle;
                navigation.UrlRoot = request.UrlRoot;

                _navigationWriteRepository.Update(navigation);
                await _navigationWriteRepository.SaveAsync();

                return new()
                {
                    Message = "Güncelleme başarıyla yapıldı.",
                    State = true
                };
            }
            else
            {
                return new()
                {
                    Message = "İşlem sırasında beklenmedik bir hata oluştu.",
                    State = false
                };
            }
        }

        public async Task<NavigationDeleteCommandResponse> NavigationDeleteAsync(NavigationDeleteCommandRequest request)
        {
            Navigation navigation = await _navigationReadRepository.GetByIdAsync(request.Id);
            if (navigation != null)
            {
                navigation.IsActive = false;
                _navigationWriteRepository.Update(navigation);
                await _navigationWriteRepository.SaveAsync();

                return new()
                {
                    Message = "İşlem başarıyla yapıldı.",
                    State = true
                };
            }
            else
            {
                return new()
                {
                    Message = "İşlem sırasında beklenmedik bir hata oluştu.",
                    State = false
                };
            }
        }


        #endregion
    }
}
