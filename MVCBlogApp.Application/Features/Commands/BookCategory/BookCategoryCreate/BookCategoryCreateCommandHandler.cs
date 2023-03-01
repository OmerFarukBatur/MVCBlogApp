using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.BookCategory.BookCategoryCreate
{
    public class BookCategoryCreateCommandHandler : IRequestHandler<BookCategoryCreateCommandRequest, BookCategoryCreateCommandResponse>
    {
        private readonly IBookService _bookService;

        public BookCategoryCreateCommandHandler(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<BookCategoryCreateCommandResponse> Handle(BookCategoryCreateCommandRequest request, CancellationToken cancellationToken)
        {
            BookCategoryCreateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);

            if (validation.IsValid)
            {
                return await _bookService.BookCategoryCreateAsync(request);
            }
            else
            {
                return new()
                {
                    Message = "Lütfen geçerli veriler giriniz.",
                    State = false
                };
            }
        }
    }
}
