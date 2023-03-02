using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Book.GetBookCreateItems
{
    public class GetBookCreateItemsQueryHandler : IRequestHandler<GetBookCreateItemsQueryRequest, GetBookCreateItemsQueryResponse>
    {
        private readonly IBookService _bookService;

        public GetBookCreateItemsQueryHandler(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<GetBookCreateItemsQueryResponse> Handle(GetBookCreateItemsQueryRequest request, CancellationToken cancellationToken)
        {
            return await _bookService.GetBookCreateItemsAsync();
        }
    }
}
