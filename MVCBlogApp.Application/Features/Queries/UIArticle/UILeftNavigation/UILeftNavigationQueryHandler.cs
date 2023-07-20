using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.UIArticle.UILeftNavigation
{
    public class UILeftNavigationQueryHandler : IRequestHandler<UILeftNavigationQueryRequest, UILeftNavigationQueryResponse>
    {
        private readonly IUIOtherService _service;

        public UILeftNavigationQueryHandler(IUIOtherService service)
        {
            _service = service;
        }

        public async Task<UILeftNavigationQueryResponse> Handle(UILeftNavigationQueryRequest request, CancellationToken cancellationToken)
        {
            if (request.orderNo != null && request.parentID != null)
            {
                return await _service.UILeftNavigationAsync(request);
            }
            else
            {
                return new()
                {
                    LeftNavigations = null
                };
            }
        }
    }
}
