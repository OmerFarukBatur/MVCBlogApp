using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.UIHome.GetBiography
{
    public class GetBiographyQueryHandler : IRequestHandler<GetBiographyQueryRequest, GetBiographyQueryResponse>
    {
        private readonly IUIHomeService _homeService;

        public GetBiographyQueryHandler(IUIHomeService homeService)
        {
            _homeService = homeService;
        }

        public async Task<GetBiographyQueryResponse> Handle(GetBiographyQueryRequest request, CancellationToken cancellationToken)
        {
            return await _homeService.GetBiographyAsync();
        }
    }
}
