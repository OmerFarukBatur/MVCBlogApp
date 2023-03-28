using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.SeminarVisuals.SeminarVisualsDelete
{
    public class SeminarVisualsDeleteCommandHandler : IRequestHandler<SeminarVisualsDeleteCommandRequest, SeminarVisualsDeleteCommandResponse>
    {
        private readonly IReferenceService _referenceService;

        public SeminarVisualsDeleteCommandHandler(IReferenceService referenceService)
        {
            _referenceService = referenceService;
        }

        public async Task<SeminarVisualsDeleteCommandResponse> Handle(SeminarVisualsDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _referenceService.SeminarVisualsDeleteAsync(request.Id);
            }
            else
            {
                return new()
                {
                    Message = "Lütfen geçerli değerler giriniz.",
                    State = false
                };
            }
        }
    }
}
