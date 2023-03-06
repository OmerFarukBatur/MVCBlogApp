using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Blog.GetAllBlog
{
    public class GetAllBlogQueryHandler : IRequestHandler<GetAllBlogQueryRequest, GetAllBlogQueryResponse>
    {
        private readonly IBlogService _blogService;

        public GetAllBlogQueryHandler(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public async Task<GetAllBlogQueryResponse> Handle(GetAllBlogQueryRequest request, CancellationToken cancellationToken)
        {
            return await _blogService.GetAllBlogAsync();
        }
    }
}
