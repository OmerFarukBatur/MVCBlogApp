using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.BookCategory.GetAllBookCategory
{
    public class GetAllBookCategoryCommandResponse
    {
        public List<VM_BookCategory> BookCategories { get; set; }
    }
}