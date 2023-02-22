using MVCBlogApp.Application.Features.Commands.GeneralOptions.CreateLanguage;
using MVCBlogApp.Application.Features.Commands.GeneralOptions.DeleteLanguage;
using MVCBlogApp.Application.Features.Commands.GeneralOptions.UpdateLanguage;
using MVCBlogApp.Application.Features.Queries.GeneralOptions.GetAllLanguage;
using MVCBlogApp.Application.Features.Queries.GeneralOptions.GetByIdLanguage;
using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Abstractions.Services
{
    public interface IGeneralOptionsService
    {
        Task<CreateLanguageCommandResponse> CreateLanguageAsync(CreateLanguageCommandRequest request);
        Task<List<AllLanguage>> GetAllLanguageAsync(GetAllLanguageQueryRequest request);
        Task<GetByIdLanguageQueryResponse> GetByIdLanguageAsync(GetByIdLanguageQueryRequest request);
        Task<UpdateLanguageCommandResponse> UpdateLanguageAsync(UpdateLanguageCommandRequest request);
        Task<DeleteLanguageCommandResponse> DeleteLanguageAsync(DeleteLanguageCommandRequest request);
    }
}
