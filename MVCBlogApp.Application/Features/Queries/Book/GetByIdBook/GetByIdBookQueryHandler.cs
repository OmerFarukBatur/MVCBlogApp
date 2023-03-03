using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Book.GetByIdBook
{
    public class GetByIdBookQueryHandler : IRequestHandler<GetByIdBookQueryRequest, GetByIdBookQueryResponse>
    {
        private readonly IBookService _bookService;

        public GetByIdBookQueryHandler(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<GetByIdBookQueryResponse> Handle(GetByIdBookQueryRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _bookService.GetByIdBookAsync(request);
            }
            else
            {
                return new()
                {
                    BookCategories = null,
                    BookCategoryId = null,
                    Books = null,
                    Languages = null,
                    Navigations = null,
                    Statuses = null,
                    Message = "Lütfen geçerli değerler giriniz.",
                    State = false
                };
            }
        }
    }
}
