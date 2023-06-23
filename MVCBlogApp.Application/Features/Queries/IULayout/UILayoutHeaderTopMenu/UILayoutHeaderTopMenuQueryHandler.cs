using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.IULayout.UILayoutHeaderTopMenu
{
    public class UILayoutHeaderTopMenuQueryHandler : IRequestHandler<UILayoutHeaderTopMenuQueryRequest, UILayoutHeaderTopMenuQueryResponse>
    {
        private readonly IUIHomeService _homeService;

        public UILayoutHeaderTopMenuQueryHandler(IUIHomeService homeService)
        {
            _homeService = homeService;
        }

        public async Task<UILayoutHeaderTopMenuQueryResponse> Handle(UILayoutHeaderTopMenuQueryRequest request, CancellationToken cancellationToken)
        {
            return await _homeService.UILayoutHeaderTopMenuAsync();
        }
    }
}
