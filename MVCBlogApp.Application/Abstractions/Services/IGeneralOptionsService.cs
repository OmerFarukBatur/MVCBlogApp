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
        Task<GetByIdNavigationQueryResponse> GetByIdNavigationAsync(GetByIdNavigationQueryRequest request);
        Task<NavigationUpdateCommandResponse> NavigationUpdateAsync(NavigationUpdateCommandRequest request);
        Task<NavigationDeleteCommandResponse> NavigationDeleteAsync(NavigationDeleteCommandRequest request);

        #endregion

        #region URL Create

        string URLCreate(string title);

        #endregion
    }
}
