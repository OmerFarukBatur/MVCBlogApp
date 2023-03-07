using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.Blog.GetByIdBlog
{
    public class GetByIdBlogQueryResponse
    {
        public string? Message { get; set; }
        public bool State { get; set; }
        public List<VM_BlogCategory>? BlogCategories { get; set; }
        public List<VM_BlogType>? BlogTypes { get; set; }
        public List<AllStatus>? Statuses { get; set; }
        public List<VM_Language>? Languages { get; set; }
        public List<VM_Navigation>? Navigations { get; set; }
        public VM_Blog? Blog { get; set; }
    }
}