using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.UIBlog.BlogCategoryIndex
{
    public class BlogCategoryIndexQueryHandler : IRequestHandler<BlogCategoryIndexQueryRequest, BlogCategoryIndexQueryResponse>
    {
        private readonly IUIOtherService _service;

        public BlogCategoryIndexQueryHandler(IUIOtherService service)
        {
            _service = service;
        }

        public async Task<BlogCategoryIndexQueryResponse> Handle(BlogCategoryIndexQueryRequest request, CancellationToken cancellationToken)
        {
            return await _service.BlogCategoryIndexAsync(request);
        }
    }
}
