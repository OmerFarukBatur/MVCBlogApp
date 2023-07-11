using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.IULayout.UILayoutFooter
{
    public class UILayoutFooterQueryHandler : IRequestHandler<UILayoutFooterQueryRequest, UILayoutFooterQueryResponse>
    {
        private readonly IUIHomeService _homeService;

        public UILayoutFooterQueryHandler(IUIHomeService homeService)
        {
            _homeService = homeService;
        }

        public async Task<UILayoutFooterQueryResponse> Handle(UILayoutFooterQueryRequest request, CancellationToken cancellationToken)
        {
            return await _homeService.UILayoutFooterAsync();
        }
    }
}
