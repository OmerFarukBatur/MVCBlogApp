using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.UIBook.GetAllActiveBooks
{
    public class GetAllActiveBlogQueryHandler : IRequestHandler<GetAllActiveBlogQueryRequest, GetAllActiveBlogQueryResponse>
    {
        private readonly IUIOtherService _uIOtherService;

        public GetAllActiveBlogQueryHandler(IUIOtherService uIOtherService)
        {
            _uIOtherService = uIOtherService;
        }

        public async Task<GetAllActiveBlogQueryResponse> Handle(GetAllActiveBlogQueryRequest request, CancellationToken cancellationToken)
        {
            return await _uIOtherService.GetAllActiveBooksAsync();
        }
    }
}
