using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.UIHome.GetPage
{
    public class GetPageQueryHandler : IRequestHandler<GetPageQueryRequest, GetPageQueryResponse>
    {
        private readonly IUIHomeService _uiHomeService;

        public GetPageQueryHandler(IUIHomeService uiHomeService)
        {
            _uiHomeService = uiHomeService;
        }

        public async Task<GetPageQueryResponse> Handle(GetPageQueryRequest request, CancellationToken cancellationToken)
        {
            return await _uiHomeService.GetPageAsync(request);
        }
    }
}
