using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.Book.GetBookCreateItems
{
    public class GetBookCreateItemsQueryResponse
    {
        public List<VM_Language> Languages { get; set; }
        public List<VM_Navigation> Navigations { get; set; }
        public List<AllStatus> Statuses { get; set; }
        public List<VM_BookCategory> BookCategories { get; set; }
    }
}