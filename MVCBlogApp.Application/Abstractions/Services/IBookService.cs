using MVCBlogApp.Application.Features.Commands.BookCategory.BookCategoryCreate;
using MVCBlogApp.Application.Features.Commands.BookCategory.BookCategoryDelete;
using MVCBlogApp.Application.Features.Commands.BookCategory.BookCategoryUpdate;
using MVCBlogApp.Application.Features.Queries.BookCategory.GetAllBookCategory;
using MVCBlogApp.Application.Features.Queries.BookCategory.GetBookCatgoryCreateItem;
using MVCBlogApp.Application.Features.Queries.BookCategory.GetByIdBookCategory;

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
        Task<GetByIdBookCategoryQueryResponse> GetByIdBookCategoryAsync(GetByIdBookCategoryQueryRequest request);
        Task<BookCategoryUpdateCommandResponse> BookCategoryUpdateAsync(BookCategoryUpdateCommandRequest request);
        Task<BookCategoryDeleteCommandResponse> BookCategoryDeleteAsync(BookCategoryDeleteCommandRequest request);

        #endregion
    }
}
