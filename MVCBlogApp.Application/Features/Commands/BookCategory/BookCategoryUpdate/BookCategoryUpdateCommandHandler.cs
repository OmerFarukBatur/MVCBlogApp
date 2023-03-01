using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.BookCategory.BookCategoryUpdate
{
    public class BookCategoryUpdateCommandHandler : IRequestHandler<BookCategoryUpdateCommandRequest, BookCategoryUpdateCommandResponse>
    {
        private readonly IBookService _bookService;

        public BookCategoryUpdateCommandHandler(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<BookCategoryUpdateCommandResponse> Handle(BookCategoryUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            BookCategoryUpdateCommandValidator validationRules = new();
            ValidationResult result = validationRules.Validate(request);

            if (result.IsValid)
            {
                return await _bookService.BookCategoryUpdateAsync(request);
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
