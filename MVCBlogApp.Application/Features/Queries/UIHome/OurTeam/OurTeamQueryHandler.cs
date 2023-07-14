using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.UIHome.OurTeam
{
    public class OurTeamQueryHandler : IRequestHandler<OurTeamQueryRequest, OurTeamQueryResponse>
    {
        private readonly IUIHomeService _homeService;

        public OurTeamQueryHandler(IUIHomeService homeService)
        {
            _homeService = homeService;
        }

        public async Task<OurTeamQueryResponse> Handle(OurTeamQueryRequest request, CancellationToken cancellationToken)
        {
            return await _homeService.OurTeamAsync();
        }
    }
}
