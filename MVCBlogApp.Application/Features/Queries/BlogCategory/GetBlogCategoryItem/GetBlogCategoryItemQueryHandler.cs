using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.BlogCategory.GetBlogCategoryItem
{
    public class GetBlogCategoryItemQueryHandler : IRequestHandler<GetBlogCategoryItemQueryRequest, GetBlogCategoryItemQueryResponse>
    {
        private readonly IBlogService _blogService;

        public GetBlogCategoryItemQueryHandler(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public async Task<GetBlogCategoryItemQueryResponse> Handle(GetBlogCategoryItemQueryRequest request, CancellationToken cancellationToken)
        {
            return await _blogService.GetBlogCategoryItemAsync();
        }
    }
}
