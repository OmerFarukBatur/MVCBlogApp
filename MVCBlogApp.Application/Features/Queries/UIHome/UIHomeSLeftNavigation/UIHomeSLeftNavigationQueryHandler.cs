using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.UIHome.UIHomeSLeftNavigation
{
    public class UIHomeSLeftNavigationQueryHandler : IRequestHandler<UIHomeSLeftNavigationQueryRequest, UIHomeSLeftNavigationQueryResponse>
    {
        private readonly IUIHomeService _uiHomeService;

        public UIHomeSLeftNavigationQueryHandler(IUIHomeService uiHomeService)
        {
            _uiHomeService = uiHomeService;
        }

        public async Task<UIHomeSLeftNavigationQueryResponse> Handle(UIHomeSLeftNavigationQueryRequest request, CancellationToken cancellationToken)
        {
            return await _uiHomeService.UIHomeSLeftNavigationAsync();
        }
    }
}
