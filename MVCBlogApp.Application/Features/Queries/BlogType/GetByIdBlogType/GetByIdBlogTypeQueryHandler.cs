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

        public async Task<GetByIdBlogTypeQueryResponse> Handle(GetByIdBlogTypeQueryRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _blogService.GetByIdBlogTypeAsync(request);
            }
            else
            {
                return new()
                {
                    State = false,
                    BlogType = null,
                    Message = "Lütfen geçerli bilgiler giriniz."
                };
            }
        }
    }
}
