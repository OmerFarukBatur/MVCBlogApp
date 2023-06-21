using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.UIHome.UIHomeSlider
{
    public class UIHomeSliderQueryHandler : IRequestHandler<UIHomeSliderQueryRequest, UIHomeSliderQueryResponse>
    {
        private readonly IUIHomeService _uiHomeService;

        public UIHomeSliderQueryHandler(IUIHomeService uiHomeService)
        {
            _uiHomeService = uiHomeService;
        }

        public async Task<UIHomeSliderQueryResponse> Handle(UIHomeSliderQueryRequest request, CancellationToken cancellationToken)
        {
            return await _uiHomeService.UIHomeSliderAsync();
        }
    }
}
