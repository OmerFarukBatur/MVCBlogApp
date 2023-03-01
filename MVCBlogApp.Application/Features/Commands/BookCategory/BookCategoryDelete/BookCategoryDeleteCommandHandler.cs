using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.BookCategory.BookCategoryDelete
{
    public class BookCategoryDeleteCommandHandler : IRequestHandler<BookCategoryDeleteCommandRequest, BookCategoryDeleteCommandResponse>
    {
        private readonly IBookService _bookService;

        public BookCategoryDeleteCommandHandler(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<BookCategoryDeleteCommandResponse> Handle(BookCategoryDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _bookService.BookCategoryDeleteAsync(request);
            }
            else
            {
                return new()
                {
                    Message = "Lütfen geçerli degerler giriniz.",
                    State = false
                };
            }
        }
    }
}
