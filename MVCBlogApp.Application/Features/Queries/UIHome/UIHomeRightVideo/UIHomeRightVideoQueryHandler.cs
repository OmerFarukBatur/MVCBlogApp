using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.UIHome.UIHomeRightVideo
{
    public class UIHomeRightVideoQueryHandler : IRequestHandler<UIHomeRightVideoQueryRequest, UIHomeRightVideoQueryResponse>
    {
        private readonly IUIHomeService _uiHomeService;

        public UIHomeRightVideoQueryHandler(IUIHomeService uiHomeService)
        {
            _uiHomeService = uiHomeService;
        }

        public async Task<UIHomeRightVideoQueryResponse> Handle(UIHomeRightVideoQueryRequest request, CancellationToken cancellationToken)
        {
            return await _uiHomeService.UIHomeRightVideoAsync();
        }
    }
}
