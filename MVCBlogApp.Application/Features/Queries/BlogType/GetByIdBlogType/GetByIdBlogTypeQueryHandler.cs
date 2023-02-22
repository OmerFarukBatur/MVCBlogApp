using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.BlogType.GetByIdBlogType
{
    public class GetByIdBlogTypeQueryHandler : IRequestHandler<GetByIdBlogTypeQueryRequest, GetByIdBlogTypeQueryResponse>
    {
        private readonly IBlogService _blogService;

        public GetByIdBlogTypeQueryHandler(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public Task<GetByIdBlogTypeQueryResponse> Handle(GetByIdBlogTypeQueryRequest request, CancellationToken cancellationToken)
        {
            return _blogService.GetByIdBlogTypeAsync(request);
        }
    }
}
