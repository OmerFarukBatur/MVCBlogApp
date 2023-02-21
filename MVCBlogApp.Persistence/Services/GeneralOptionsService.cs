using Microsoft.EntityFrameworkCore;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Features.Commands.GeneralOptions.CreateLanguage;
using MVCBlogApp.Application.Features.Queries.GeneralOptions.GetAllLanguage;
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

        public async Task<List<AllLanguage>> GetAllLanguage(GetAllLanguageQueryRequest request)
        {
            List<AllLanguage> allLanguages = await _languagesReadRepository.GetAll().Select(a => new AllLanguage 
            {
                Id = a.ID,
                Language = a.Language,
                IsActive= a.IsActive,
                CreatedDate = a.CreateDate
            }).ToListAsync();

            return allLanguages;
        }
    }
}
