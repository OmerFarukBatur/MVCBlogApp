using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.UIHome.UIHomeIndex
{
    public class UIHomeIndexQueryHandler : IRequestHandler<UIHomeIndexQueryRequest, UIHomeIndexQueryResponse>
    {
        private readonly IUIHomeService _uiHomeService;

        public UIHomeIndexQueryHandler(IUIHomeService uiHomeService)
        {
            _uiHomeService = uiHomeService;
        }

        public async Task<UIHomeIndexQueryResponse> Handle(UIHomeIndexQueryRequest request, CancellationToken cancellationToken)
        {
            return await _uiHomeService.UIHomeIndexAsync();
        }
    }
}
