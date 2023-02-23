using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.BlogCategory.GetAllBlogCategory
{
    public class GetAllBlogCategoryQueryHandler : IRequestHandler<GetAllBlogCategoryQueryRequest, GetAllBlogCategoryQueryResponse>
    {
        private readonly IBlogService _blogService;

        public GetAllBlogCategoryQueryHandler(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public async Task<GetAllBlogCategoryQueryResponse> Handle(GetAllBlogCategoryQueryRequest request, CancellationToken cancellationToken)
        {
           return await _blogService.GetAllBlogCategoryAsync();
        }
    }
}
