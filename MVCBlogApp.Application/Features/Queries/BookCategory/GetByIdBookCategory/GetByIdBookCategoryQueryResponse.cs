using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.BookCategory.GetByIdBookCategory
{
    public class GetByIdBookCategoryQueryResponse
    {
        public VM_BookCategory? BookCategory { get; set; }
        public List<VM_Language>? Languages { get; set; }
        public List<AllStatus>? Statuses { get; set; }
        public string? Message { get; set; }
        public bool State { get; set; }
    }
}