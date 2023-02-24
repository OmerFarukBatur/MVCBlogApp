using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.GeneralOptions.Navigation.GetNavigationCreateItems
{
    public class GetNavigationCreateItemsCommandResponse
    {
        public List<VM_Navigation> Navigations { get; set; }
        public List<VM_Language> Languages { get; set; }
    }
}