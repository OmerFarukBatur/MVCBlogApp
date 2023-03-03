using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Book.GetAllBook
{
    public class GetAllBookCommandHandler : IRequestHandler<GetAllBookCommandRequest, GetAllBookCommandResponse>
    {
        private readonly IBookService _bookService;

        public GetAllBookCommandHandler(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<GetAllBookCommandResponse> Handle(GetAllBookCommandRequest request, CancellationToken cancellationToken)
        {
            return await _bookService.GetAllBookAsync();
        }
    }
}
