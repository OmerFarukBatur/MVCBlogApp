using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.ReferenceAndOuther.OurTeam.GetByIdOurTeam
{
    public class GetByIdOurTeamQueryHandler : IRequestHandler<GetByIdOurTeamQueryRequest, GetByIdOurTeamQueryResponse>
    {
        private readonly IReferenceService _referenceService;

        public GetByIdOurTeamQueryHandler(IReferenceService referenceService)
        {
            _referenceService = referenceService;
        }

        public async Task<GetByIdOurTeamQueryResponse> Handle(GetByIdOurTeamQueryRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _referenceService.GetByIdOurTeamAsync(request.Id);
            }
            else
            {
                return new()
                {
                    Languages = null,
                    OurTeam = null,
                    Statuses = null,
                    State = false,
                    Message = "Bilgiye ait kayıt bulunamamıştır."
                };
            }
        }
    }
}
