using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.UIHome.ConfessionsPartialView
{
    public class ConfessionsPartialViewQueryHandler : IRequestHandler<ConfessionsPartialViewQueryRequest, ConfessionsPartialViewQueryResponse>
    {
        private readonly IUIHomeService _homeService;

        public ConfessionsPartialViewQueryHandler(IUIHomeService homeService)
        {
            _homeService = homeService;
        }

        public async Task<ConfessionsPartialViewQueryResponse> Handle(ConfessionsPartialViewQueryRequest request, CancellationToken cancellationToken)
        {
            return await _homeService.ConfessionsPartialViewAsync(request);
        }
    }
}
