using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.IULayout.UILayoutBanner
{
    public class UILayoutBannerQueryHandler : IRequestHandler<UILayoutBannerQueryRequest, UILayoutBannerQueryResponse>
    {
        private readonly IUIHomeService _homeService;

        public UILayoutBannerQueryHandler(IUIHomeService homeService)
        {
            _homeService = homeService;
        }

        public async Task<UILayoutBannerQueryResponse> Handle(UILayoutBannerQueryRequest request, CancellationToken cancellationToken)
        {
            return await _homeService.UILayoutBannerAsync();
        }
    }
}
