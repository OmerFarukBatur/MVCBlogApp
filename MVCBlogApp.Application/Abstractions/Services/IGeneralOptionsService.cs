using MVCBlogApp.Application.Features.Commands.GeneralOptions.Form.FormCreate;
using MVCBlogApp.Application.Features.Commands.GeneralOptions.Form.FormDelete;
using MVCBlogApp.Application.Features.Commands.GeneralOptions.Form.FormUpdate;
using MVCBlogApp.Application.Features.Commands.GeneralOptions.Languages.CreateLanguage;
using MVCBlogApp.Application.Features.Commands.GeneralOptions.Languages.DeleteLanguage;
using MVCBlogApp.Application.Features.Commands.GeneralOptions.Languages.UpdateLanguage;
using MVCBlogApp.Application.Features.Commands.GeneralOptions.Navigation.NavigationCreate;
using MVCBlogApp.Application.Features.Commands.GeneralOptions.Navigation.NavigationDelete;
using MVCBlogApp.Application.Features.Commands.GeneralOptions.Navigation.NavigationUpdate;
using MVCBlogApp.Application.Features.Queries.GeneralOptions.Form.GetAllForms;
using MVCBlogApp.Application.Features.Queries.GeneralOptions.Form.GetByIdForm;
using MVCBlogApp.Application.Features.Queries.GeneralOptions.Form.GetFormCreateItems;
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

        #region Form

        Task<GetFormCreateItemsQueryResponse> GetFormCreateItemsAsync();
        Task<GetAllFormsQueryResponse> GetAllFormsAsync();
        Task<FormCreateCommandResponse> FormCreateAsync(FormCreateCommandRequest request);
        Task<GetByIdFormQueryResponse> GetByIdFormAsync(int id);
        Task<FormUpdateQueryResponse> FormUpdateAsync(FormUpdateQueryRequest request);
        Task<FormDeleteCommandResponse> FormDeleteAsync(int id);

        #endregion
    }
}
