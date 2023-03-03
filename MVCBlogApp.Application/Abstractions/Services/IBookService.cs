using MVCBlogApp.Application.Features.Commands.Book.BookCreate;
using MVCBlogApp.Application.Features.Commands.Book.BookDelete;
using MVCBlogApp.Application.Features.Commands.Book.BookUpdate;
using MVCBlogApp.Application.Features.Commands.BookCategory.BookCategoryCreate;
using MVCBlogApp.Application.Features.Commands.BookCategory.BookCategoryDelete;
using MVCBlogApp.Application.Features.Commands.BookCategory.BookCategoryUpdate;
using MVCBlogApp.Application.Features.Queries.Book.GetAllBook;
using MVCBlogApp.Application.Features.Queries.Book.GetBookCreateItems;
using MVCBlogApp.Application.Features.Queries.Book.GetByIdBook;
using MVCBlogApp.Application.Features.Queries.BookCategory.GetAllBookCategory;
using MVCBlogApp.Application.Features.Queries.BookCategory.GetBookCatgoryCreateItem;
using MVCBlogApp.Application.Features.Queries.BookCategory.GetByIdBookCategory;

namespace MVCBlogApp.Application.Abstractions.Services
{
    public interface IBookService
    {
        #region Book

        Task<GetBookCreateItemsQueryResponse> GetBookCreateItemsAsync();
        Task<BookCreateCommandResponse> BookCreateAsync(BookCreateCommandRequest request);
        Task<GetAllBookQueryResponse> GetAllBookAsync();
        Task<GetByIdBookQueryResponse> GetByIdBookAsync(GetByIdBookQueryRequest request);
        Task<BookUpdateCommandResponse> BookUpdateAsync(BookUpdateCommandRequest request);
        Task<BookDeleteCommandResponse> BookDeleteAsync(BookDeleteCommandRequest request);

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
