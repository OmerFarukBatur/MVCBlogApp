using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.OurTeam.OurTeamDelete
{
    public class OurTeamDeleteCommandHandler : IRequestHandler<OurTeamDeleteCommandRequest, OurTeamDeleteCommandResponse>
    {
        private readonly IReferenceService _referenceService;

        public OurTeamDeleteCommandHandler(IReferenceService referenceService)
        {
            _referenceService = referenceService;
        }

        public async Task<OurTeamDeleteCommandResponse> Handle(OurTeamDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _referenceService.OurTeamDeleteAsync(request.Id);
            }
            else
            {
                return new()
                {
                    State = false,
                    Message = "Bilgiye ait kayıt bulunamamıştır."
                };
            }
        }
    }
}
