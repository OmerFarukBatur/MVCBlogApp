using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.UIHome.GetSearchData
{
    public class GetSearchDataQueryHandler : IRequestHandler<GetSearchDataQueryRequest, GetSearchDataQueryResponse>
    {
        private readonly IUIHomeService _uIHomeService;

        public GetSearchDataQueryHandler(IUIHomeService uIHomeService)
        {
            _uIHomeService = uIHomeService;
        }

        public async Task<GetSearchDataQueryResponse> Handle(GetSearchDataQueryRequest request, CancellationToken cancellationToken)
        {
            return await _uIHomeService.GetSearchDataAsync(request);
        }
    }
}
