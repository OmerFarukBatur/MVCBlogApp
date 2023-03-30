using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.PressType.PressTypeDelete
{
    public class PressTypeDeleteCommandHandler : IRequestHandler<PressTypeDeleteCommandRequest, PressTypeDeleteCommandResponse>
    {
        private readonly IReferenceService _referenceService;

        public PressTypeDeleteCommandHandler(IReferenceService referenceService)
        {
            _referenceService = referenceService;
        }

        public async Task<PressTypeDeleteCommandResponse> Handle(PressTypeDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _referenceService.PressTypeDeleteAsync(request.Id);
            }
            else
            {
                return new()
                {
                    Message = "Kayıt bulunamamıştır."
                };
            }
        }
    }
}
