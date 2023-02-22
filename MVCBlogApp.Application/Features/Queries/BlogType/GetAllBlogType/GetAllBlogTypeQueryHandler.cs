using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.BlogType.GetAllBlogType
{
    public class GetAllBlogTypeQueryHandler : IRequestHandler<GetAllBlogTypeQueryRequest, GetAllBlogTypeQueryResponse>
    {
        private readonly IBlogService _blogService;

        public GetAllBlogTypeQueryHandler(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public async Task<GetAllBlogTypeQueryResponse> Handle(GetAllBlogTypeQueryRequest request, CancellationToken cancellationToken)
        {
            return await _blogService.GetAllBlogTypeAsync();
        }
    }
}
