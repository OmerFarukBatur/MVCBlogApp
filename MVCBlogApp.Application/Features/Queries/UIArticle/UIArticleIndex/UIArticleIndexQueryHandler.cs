using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.UIArticle.UIArticleIndex
{
    public class UIArticleIndexQueryHandler : IRequestHandler<UIArticleIndexQueryRequest, UIArticleIndexQueryResponse>
    {
        private readonly IUIOtherService _service;

        public UIArticleIndexQueryHandler(IUIOtherService service)
        {
            _service = service;
        }

        public async Task<UIArticleIndexQueryResponse> Handle(UIArticleIndexQueryRequest request, CancellationToken cancellationToken)
        {
            if (request.id != null)
            {
                return await _service.UIArticleIndexAsync(request);
            }
            else
            {
                return new()
                {
                    Article = null
                };
            }

        }
    }
}
