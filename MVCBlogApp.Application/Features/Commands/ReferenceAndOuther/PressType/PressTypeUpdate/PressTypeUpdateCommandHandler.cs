using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.PressType.PressTypeUpdate
{
    public class PressTypeUpdateCommandHandler : IRequestHandler<PressTypeUpdateCommandRequest, PressTypeUpdateCommandResponse>
    {
        private readonly IReferenceService _referenceService;

        public PressTypeUpdateCommandHandler(IReferenceService referenceService)
        {
            _referenceService = referenceService;
        }

        public async Task<PressTypeUpdateCommandResponse> Handle(PressTypeUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.PressTypeName != "" && request.PressTypeName != null && (request.PressTypeName.Length > 1 && request.PressTypeName.Length < 51))
            {
                return await _referenceService.PressTypeUpdateAsync(request);
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
