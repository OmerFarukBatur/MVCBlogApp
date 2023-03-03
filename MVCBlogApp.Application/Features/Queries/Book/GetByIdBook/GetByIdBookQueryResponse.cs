using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.Book.GetByIdBook
{
    public class GetByIdBookQueryResponse
    {
        public VM_Book? Books { get; set; }
        public List<VM_Language>? Languages { get; set; }
        public List<AllStatus>? Statuses { get; set; }
        public List<VM_Navigation>? Navigations { get; set; }
        public List<VM_BookCategory>? BookCategories { get; set; }
        public List<int>? BookCategoryId { get; set; }
        public string? Message { get; set; }
        public bool State { get; set; }
    }
}