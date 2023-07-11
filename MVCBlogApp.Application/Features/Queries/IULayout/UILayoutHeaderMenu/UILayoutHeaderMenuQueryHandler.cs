using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.IULayout.UILayoutHeaderMenu
{
    public class UILayoutHeaderMenuQueryHandler : IRequestHandler<UILayoutHeaderMenuQueryRequest, UILayoutHeaderMenuQueryResponse>
    {
        private readonly IUIHomeService _homeService;

        public UILayoutHeaderMenuQueryHandler(IUIHomeService homeService)
        {
            _homeService = homeService;
        }

        public async Task<UILayoutHeaderMenuQueryResponse> Handle(UILayoutHeaderMenuQueryRequest request, CancellationToken cancellationToken)
        {
            return await _homeService.UILayoutHeaderMenuAsync();
        }
    }
}
