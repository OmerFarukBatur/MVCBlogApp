using MVCBlogApp.Application.Features.Commands.GeneralOptions.CreateLanguage;
using MVCBlogApp.Application.Features.Queries.GeneralOptions.GetAllLanguage;
using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Abstractions.Services
{
    public interface IGeneralOptionsService
    {
        Task<CreateLanguageCommandResponse> CreateLanguageAsync(CreateLanguageCommandRequest request);
        Task<List<AllLanguage>> GetAllLanguage(GetAllLanguageQueryRequest request);
    }
}
