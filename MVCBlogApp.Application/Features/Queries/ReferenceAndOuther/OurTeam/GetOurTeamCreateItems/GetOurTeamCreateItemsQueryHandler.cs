using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.ReferenceAndOuther.OurTeam.GetOurTeamCreateItems
{
    public class GetOurTeamCreateItemsQueryHandler : IRequestHandler<GetOurTeamCreateItemsQueryRequest, GetOurTeamCreateItemsQueryResponse>
    {
        private readonly IReferenceService _referenceService;

        public GetOurTeamCreateItemsQueryHandler(IReferenceService referenceService)
        {
            _referenceService = referenceService;
        }

        public async Task<GetOurTeamCreateItemsQueryResponse> Handle(GetOurTeamCreateItemsQueryRequest request, CancellationToken cancellationToken)
        {
            return await _referenceService.GetOurTeamCreateItemsAsync();
        }
    }
}
