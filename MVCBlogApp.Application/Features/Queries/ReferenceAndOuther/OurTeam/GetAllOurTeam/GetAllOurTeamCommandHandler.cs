using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.ReferenceAndOuther.OurTeam.GetAllOurTeam
{
    public class GetAllOurTeamCommandHandler : IRequestHandler<GetAllOurTeamCommandRequest, GetAllOurTeamCommandResponse>
    {
        private readonly IReferenceService _referenceService;

        public GetAllOurTeamCommandHandler(IReferenceService referenceService)
        {
            _referenceService = referenceService;
        }

        public async Task<GetAllOurTeamCommandResponse> Handle(GetAllOurTeamCommandRequest request, CancellationToken cancellationToken)
        {
            return await _referenceService.GetAllOurTeamAsync();
        }
    }
}
