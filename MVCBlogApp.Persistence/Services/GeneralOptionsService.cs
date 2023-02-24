using Microsoft.EntityFrameworkCore;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Features.Commands.GeneralOptions.CreateLanguage;
using MVCBlogApp.Application.Features.Commands.GeneralOptions.DeleteLanguage;
using MVCBlogApp.Application.Features.Commands.GeneralOptions.UpdateLanguage;
using MVCBlogApp.Application.Features.Queries.GeneralOptions.GetAllLanguage;
using MVCBlogApp.Application.Features.Queries.GeneralOptions.GetByIdLanguage;
using MVCBlogApp.Application.Repositories.Languages;
using MVCBlogApp.Application.ViewModels;
using MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Services
{
    public class GeneralOptionsService : IGeneralOptionsService
    {
        private readonly ILanguagesReadRepository _languagesReadRepository;
        private readonly ILanguagesWriteRepository _languagesWriteRepository;

        public GeneralOptionsService(ILanguagesReadRepository languagesReadRepository, ILanguagesWriteRepository languagesWriteRepository)
        {
            _languagesReadRepository = languagesReadRepository;
            _languagesWriteRepository = languagesWriteRepository;
        }

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
                Id = a.ID,
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
                        Id = language.ID,
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
    }
}
