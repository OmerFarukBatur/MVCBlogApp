using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.UIHome.GetReferences
{
    public class GetReferencesQueryHandler : IRequestHandler<GetReferencesQueryRequest, GetReferencesQueryResponse>
    {
        private readonly IUIHomeService _homeService;

        public GetReferencesQueryHandler(IUIHomeService homeService)
        {
            _homeService = homeService;
        }

        public async Task<GetReferencesQueryResponse> Handle(GetReferencesQueryRequest request, CancellationToken cancellationToken)
        {
            return await _homeService.GetReferencesAsync();
        }
    }
}
