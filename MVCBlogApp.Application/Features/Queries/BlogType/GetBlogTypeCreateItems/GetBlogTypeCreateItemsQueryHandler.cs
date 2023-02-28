using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.BlogType.GetBlogTypeCreateItems
{
    public class GetBlogTypeCreateItemsQueryHandler : IRequestHandler<GetBlogTypeCreateItemsQueryRequest, GetBlogTypeCreateItemsQueryResponse>
    {
        private readonly IBlogService _blogService;

        public GetBlogTypeCreateItemsQueryHandler(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public async Task<GetBlogTypeCreateItemsQueryResponse> Handle(GetBlogTypeCreateItemsQueryRequest request, CancellationToken cancellationToken)
        {
            return await _blogService.GetBlogTypeCreateItemsAsync();
        }
    }
}
