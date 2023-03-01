using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.BookCategory.GetAllBookCategory
{
    public class GetAllBookCategoryCommandHandler : IRequestHandler<GetAllBookCategoryCommandRequest, GetAllBookCategoryCommandResponse>
    {
        private readonly IBookService _bookService;

        public GetAllBookCategoryCommandHandler(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<GetAllBookCategoryCommandResponse> Handle(GetAllBookCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            return await _bookService.GetAllBookCategoriesAsync();
        }
    }
}
