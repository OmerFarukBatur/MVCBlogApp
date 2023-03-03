using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Book.BookDelete
{
    public class BookDeleteCommandHandler : IRequestHandler<BookDeleteCommandRequest, BookDeleteCommandResponse>
    {
        private readonly IBookService _bookService;

        public BookDeleteCommandHandler(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<BookDeleteCommandResponse> Handle(BookDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.Id >0)
            {
                return await _bookService.BookDeleteAsync(request);
            }
            else
            {
                return new()
                {
                    Message = "Lütfen geçerli değerler giriniz.",
                    State = false
                };
            }
        }
    }
}
