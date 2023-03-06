using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Blog.GetBlogCreateItems
{
    public class GetBlogCreateItemsQueryHandler : IRequestHandler<GetBlogCreateItemsQueryRequest, GetBlogCreateItemsQueryResponse>
    {
        private readonly IBlogService _blogService;

        public GetBlogCreateItemsQueryHandler(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public async Task<GetBlogCreateItemsQueryResponse> Handle(GetBlogCreateItemsQueryRequest request, CancellationToken cancellationToken)
        {
            return await _blogService.GetBlogCreateItemsAsync();
        }
    }
}
