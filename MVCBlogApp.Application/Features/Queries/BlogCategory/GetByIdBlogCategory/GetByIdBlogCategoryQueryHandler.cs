using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.BlogCategory.GetByIdBlogCategory
{
    public class GetByIdBlogCategoryQueryHandler : IRequestHandler<GetByIdBlogCategoryQueryRequest, GetByIdBlogCategoryQueryResponse>
    {
        private readonly IBlogService _blogService;

        public GetByIdBlogCategoryQueryHandler(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public async Task<GetByIdBlogCategoryQueryResponse> Handle(GetByIdBlogCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _blogService.GetByIdBlogCategoryAsync(request);
            }
            else
            {
                return new()
                {
                    AllLanguages = null,
                    AllStatuses = null,
                    BlogCategory = null,
                    State = false
                };
            }
        }
    }
}
