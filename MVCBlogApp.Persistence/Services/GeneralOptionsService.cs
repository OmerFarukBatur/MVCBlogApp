using Microsoft.EntityFrameworkCore;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Features.Commands.GeneralOptions.Languages.CreateLanguage;
using MVCBlogApp.Application.Features.Commands.GeneralOptions.Languages.DeleteLanguage;
using MVCBlogApp.Application.Features.Commands.GeneralOptions.Languages.UpdateLanguage;
using MVCBlogApp.Application.Features.Commands.GeneralOptions.Navigation.NavigationCreate;
using MVCBlogApp.Application.Features.Queries.GeneralOptions.Languages.GetAllLanguage;
using MVCBlogApp.Application.Features.Queries.GeneralOptions.Languages.GetByIdLanguage;
using MVCBlogApp.Application.Features.Queries.GeneralOptions.Navigation.GetAllNavigation;
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
                IsActive= (bool)a.IsActive,
                CreatedDate = a.CreateDate
            }).ToListAsync();

            return allLanguages;
        }

        public async Task<GetByIdLanguageQueryResponse> GetByIdLanguageAsync(GetByIdLanguageQueryRequest request)
        {
            if (request.Id >0)
            {
                 Languages language = await _languagesReadRepository.GetByIdAsync(request.Id);
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
            var navigationList = await _navigationReadRepository.GetWhere(x=> x.NavigationName.Trim().ToLower() == request.NavigationName.Trim().ToLower() || x.NavigationName.Trim().ToUpper() == request.NavigationName.Trim().ToUpper()).ToListAsync();

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
                Id= x.Id,
                MetaTitle= x.MetaTitle,
                NavigationName= x.NavigationName
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
                .Join(_languagesReadRepository.GetAll(),na=> na.LangId,la=> la.Id,(na,la)=> new {na,la})
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


        #endregion
    }
}
