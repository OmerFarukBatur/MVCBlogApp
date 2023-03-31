using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.Press.PressDelete
{
    public class PressDeleteCommandHandler : IRequestHandler<PressDeleteCommandRequest, PressDeleteCommandResponse>
    {
        private readonly IReferenceService _referenceService;

        public PressDeleteCommandHandler(IReferenceService referenceService)
        {
            _referenceService = referenceService;
        }

        public async Task<PressDeleteCommandResponse> Handle(PressDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _referenceService.PressDeleteAsync(request.Id);
            }
            else
            {
                return new()
                {
                    State = false
                };
            }
        }
    }
}
