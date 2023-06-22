using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.UIHome.UIHomeArticlePreviews
{
    public class UIHomeArticlePreviewsQueryHandler : IRequestHandler<UIHomeArticlePreviewsQueryRequest, UIHomeArticlePreviewsQueryResponse>
    {
        private readonly IUIHomeService _uiHomeService;

        public UIHomeArticlePreviewsQueryHandler(IUIHomeService uiHomeService)
        {
            _uiHomeService = uiHomeService;
        }

        public async Task<UIHomeArticlePreviewsQueryResponse> Handle(UIHomeArticlePreviewsQueryRequest request, CancellationToken cancellationToken)
        {
            return await _uiHomeService.UIHomeArticlePreviewsAsync();
        }
    }
}
