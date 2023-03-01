using MVCBlogApp.Application.Features.Commands.BookCategory.BookCategoryCreate;
using MVCBlogApp.Application.Features.Queries.BookCategory.GetAllBookCategory;
using MVCBlogApp.Application.Features.Queries.BookCategory.GetBookCatgoryCreateItem;

namespace MVCBlogApp.Application.Abstractions.Services
{
    public interface IBookService
    {
        #region Book
        #endregion

        #region BookCategory

        Task<GetBookCatgoryCreateItemCommandResponse> GetBookCatgoryCreateItemAsync();
        Task<BookCategoryCreateCommandResponse> BookCategoryCreateAsync(BookCategoryCreateCommandRequest request);
        Task<GetAllBookCategoryCommandResponse> GetAllBookCategoriesAsync();

        #endregion
    }
}
