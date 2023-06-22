using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.UIHome.UIHomeLatestNews
{
    public class UIHomeLatestNewsQueryHandler : IRequestHandler<UIHomeLatestNewsQueryRequest, UIHomeLatestNewsQueryResponse>
    {
        private readonly IUIHomeService _uiHomeService;

        public UIHomeLatestNewsQueryHandler(IUIHomeService uiHomeService)
        {
            _uiHomeService = uiHomeService;
        }

        public async Task<UIHomeLatestNewsQueryResponse> Handle(UIHomeLatestNewsQueryRequest request, CancellationToken cancellationToken)
        {
            return await _uiHomeService.UIHomeLatestNewsAsync();
        }
    }
}
