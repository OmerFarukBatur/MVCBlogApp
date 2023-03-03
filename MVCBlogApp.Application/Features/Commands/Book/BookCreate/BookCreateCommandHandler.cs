using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Book.BookCreate
{
    public class BookCreateCommandHandler : IRequestHandler<BookCreateCommandRequest, BookCreateCommandResponse>
    {
        private readonly IBookService _bookService;

        public BookCreateCommandHandler(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<BookCreateCommandResponse> Handle(BookCreateCommandRequest request, CancellationToken cancellationToken)
        {
            BookCreateCommandValidator validationRules = new();
            ValidationResult result = validationRules.Validate(request);

            if (result.IsValid)
            {
                return await _bookService.BookCreateAsync(request);
            }
            else
            {
                return new()
                {
                    Message = "Lütfen alanları geçerli bilgilerle doldurunuz.",
                    State = false
                };
            }            
        }
    }
}
