using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.Blog.GetBlogCreateItems
{
    public class GetBlogCreateItemsQueryResponse
    {
        public List<VM_BlogCategory> BlogCategories { get; set; }
        public List<VM_BlogType> BlogTypes { get; set; }
        public List<AllStatus> Statuses { get; set; }
        public List<VM_Language> Languages { get; set; }
        public List<VM_Navigation> Navigations { get; set; }

    }
}