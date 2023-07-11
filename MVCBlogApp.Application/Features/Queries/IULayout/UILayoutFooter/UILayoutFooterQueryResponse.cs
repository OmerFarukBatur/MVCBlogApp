using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.IULayout.UILayoutFooter
{
    public class UILayoutFooterQueryResponse
    {
        public VM_TaylanK? TaylanK { get; set; }
        public List<VM_Blog> Blogs { get; set; }
        public List<VM_SLeftNavigation> SLeftNavigations { get; set; }
    }
}