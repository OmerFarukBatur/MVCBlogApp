using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.PressType.PressTypeCreate
{
    public class PressTypeCreateCommandHandler : IRequestHandler<PressTypeCreateCommandRequest, PressTypeCreateCommandResponse>
    {
        private readonly IReferenceService _referenceService;

        public PressTypeCreateCommandHandler(IReferenceService referenceService)
        {
            _referenceService = referenceService;
        }

        public async Task<PressTypeCreateCommandResponse> Handle(PressTypeCreateCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.PressTypeName != "" && request.PressTypeName != null && (request.PressTypeName.Length > 1 && request.PressTypeName.Length < 51))
            {
                return await _referenceService.PressTypeCreateAsync(request);
            }
            else
            {
                return new()
                {
                    Message = "Lütfen alanı geçerli değerlerle doldurunuz.",
                    State = false
                };
            }
        }
    }
}
