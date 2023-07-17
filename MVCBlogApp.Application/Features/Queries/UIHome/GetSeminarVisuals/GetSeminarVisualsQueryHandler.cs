using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.UIHome.GetSeminarVisuals
{
    public class GetSeminarVisualsQueryHandler : IRequestHandler<GetSeminarVisualsQueryRequest, GetSeminarVisualsQueryResponse>
    {
        private readonly IUIHomeService _uiHomeService;

        public GetSeminarVisualsQueryHandler(IUIHomeService uiHomeService)
        {
            _uiHomeService = uiHomeService;
        }

        public async Task<GetSeminarVisualsQueryResponse> Handle(GetSeminarVisualsQueryRequest request, CancellationToken cancellationToken)
        {
            return await _uiHomeService.GetSeminarVisualsAsync();
        }
    }
}
