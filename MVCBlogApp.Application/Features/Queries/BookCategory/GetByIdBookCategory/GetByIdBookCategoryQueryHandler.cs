using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.BookCategory.GetByIdBookCategory
{
    public class GetByIdBookCategoryQueryHandler : IRequestHandler<GetByIdBookCategoryQueryRequest, GetByIdBookCategoryQueryResponse>
    {
        private readonly IBookService _bookService;

        public GetByIdBookCategoryQueryHandler(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<GetByIdBookCategoryQueryResponse> Handle(GetByIdBookCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _bookService.GetByIdBookCategoryAsync(request);
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
