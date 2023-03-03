using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Book.BookUpdate
{
    public class BookUpdateCommandHandler : IRequestHandler<BookUpdateCommandRequest, BookUpdateCommandResponse>
    {
        private readonly IBookService _bookService;

        public BookUpdateCommandHandler(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<BookUpdateCommandResponse> Handle(BookUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            BookUpdateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);

            if (validation.IsValid)
            {
                return await _bookService.BookUpdateAsync(request);
            }
            else
            {
                return new()
                {
                    Message = "Lütfen alanları geçerli değerlerle doldurunuz.",
                    State = false
                };
            }
        }
    }
}
