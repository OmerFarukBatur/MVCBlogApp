using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Fix.FixPulse.FixPulseDelete
{
    public class FixPulseDeleteCommandHandler : IRequestHandler<FixPulseDeleteCommandRequest, FixPulseDeleteCommandResponse>
    {
        private readonly IFixService _fixService;

        public FixPulseDeleteCommandHandler(IFixService fixService)
        {
            _fixService = fixService;
        }

        public async Task<FixPulseDeleteCommandResponse> Handle(FixPulseDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _fixService.FixPulseDeleteAsync(request.Id);
            }
            else
            {
                return new()
                {
                    Message = "Kayıt bulunamamıştır.",
                    State = false
                };
            }
        }
    }
}
