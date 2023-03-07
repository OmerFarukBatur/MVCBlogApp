using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Blog.GetByIdBlog
{
    public class GetByIdBlogQueryHandler : IRequestHandler<GetByIdBlogQueryRequest, GetByIdBlogQueryResponse>
    {
        private readonly IBlogService _blogService;

        public GetByIdBlogQueryHandler(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public async Task<GetByIdBlogQueryResponse> Handle(GetByIdBlogQueryRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _blogService.GetByIdBlogAsync(request);
            }
            else
            {
                return new()
                {
                    Blog = null,
                    BlogCategories = null,
                    BlogTypes = null,
                    Languages = null,
                    Navigations = null,
                    Statuses = null,
                    Message = "Lütfen geçerli değerler giriniz.",
                    State = false
                };
            }
        }
    }
}
