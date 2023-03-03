using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Book.GetAllBook
{
    public class GetAllBookQueryHandler : IRequestHandler<GetAllBookQueryRequest, GetAllBookQueryResponse>
    {
        private readonly IBookService _bookService;

        public GetAllBookQueryHandler(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<GetAllBookQueryResponse> Handle(GetAllBookQueryRequest request, CancellationToken cancellationToken)
        {
            return await _bookService.GetAllBookAsync();
        }
    }
}
