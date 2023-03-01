using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.BookCategory.GetBookCatgoryCreateItem
{
    public class GetBookCatgoryCreateItemCommandHandler : IRequestHandler<GetBookCatgoryCreateItemCommandRequest, GetBookCatgoryCreateItemCommandResponse>
    {
        private readonly IBookService _bookService;

        public GetBookCatgoryCreateItemCommandHandler(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<GetBookCatgoryCreateItemCommandResponse> Handle(GetBookCatgoryCreateItemCommandRequest request, CancellationToken cancellationToken)
        {
            return await _bookService.GetBookCatgoryCreateItemAsync();
        }
    }
}
