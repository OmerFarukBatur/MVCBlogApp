using MVCBlogApp.Application.Features.Commands.GeneralOptions.Languages.CreateLanguage;
using MVCBlogApp.Application.Features.Commands.GeneralOptions.Languages.DeleteLanguage;
using MVCBlogApp.Application.Features.Commands.GeneralOptions.Languages.UpdateLanguage;
using MVCBlogApp.Application.Features.Commands.GeneralOptions.Navigation.NavigationCreate;
using MVCBlogApp.Application.Features.Queries.GeneralOptions.Languages.GetAllLanguage;
using MVCBlogApp.Application.Features.Queries.GeneralOptions.Languages.GetByIdLanguage;
using MVCBlogApp.Application.Features.Queries.GeneralOptions.Navigation.GetAllNavigation;
using MVCBlogApp.Application.Features.Queries.GeneralOptions.Navigation.GetNavigationCreateItems;
using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Abstractions.Services
{
    public interface IGeneralOptionsService
    {
        #region Language
        Task<CreateLanguageCommandResponse> CreateLanguageAsync(CreateLanguageCommandRequest request);
        Task<List<AllLanguage>> GetAllLanguageAsync(GetAllLanguageQueryRequest request);
        Task<GetByIdLanguageQueryResponse> GetByIdLanguageAsync(GetByIdLanguageQueryRequest request);
        Task<UpdateLanguageCommandResponse> UpdateLanguageAsync(UpdateLanguageCommandRequest request);
        Task<DeleteLanguageCommandResponse> DeleteLanguageAsync(DeleteLanguageCommandRequest request);
        #endregion

        #region Navigation
        
        Task<NavigationCreateCommandResponse> NavigationCreateAsync(NavigationCreateCommandRequest request);
        Task<GetNavigationCreateItemsCommandResponse> GetNavigationCreateItemsAsync();
        Task<GetAllNavigationQueryResponse> GetAllNavigationAsync();

        #endregion
    }
}
