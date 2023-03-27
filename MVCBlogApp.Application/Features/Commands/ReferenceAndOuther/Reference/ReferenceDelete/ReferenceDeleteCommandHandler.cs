using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.Reference.ReferenceDelete
{
    public class ReferenceDeleteCommandHandler : IRequestHandler<ReferenceDeleteCommandRequest, ReferenceDeleteCommandResponse>
    {
        private readonly IReferenceService _referenceService;

        public ReferenceDeleteCommandHandler(IReferenceService referenceService)
        {
            _referenceService = referenceService;
        }

        public async Task<ReferenceDeleteCommandResponse> Handle(ReferenceDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _referenceService.ReferenceDeleteAsync(request.Id);
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
