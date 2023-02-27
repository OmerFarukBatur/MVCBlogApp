using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.GeneralOptions.Navigation.GetAllNavigation
{
    public class GetAllNavigationQueryResponse
    {
        public List<VM_Navigation> AllNavigations { get; set; }
    }
}