using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.BookCategory.GetBookCatgoryCreateItem
{
    public class GetBookCatgoryCreateItemCommandResponse
    {
        public List<VM_Language> Languages { get; set; }
        public List<AllStatus> Statuses { get; set; }
    }
}