using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.GeneralOptions.Navigation.GetByIdNavigation
{
    public class GetByIdNavigationQueryResponse
    {
        public VM_Navigation? Navigation { get; set; }
        public List<VM_Language>? Languages { get; set; }
        public List<VM_Navigation>? Navigations { get; set; }
        public bool State { get; set; }
        public string? Message { get; set; }
    }
}