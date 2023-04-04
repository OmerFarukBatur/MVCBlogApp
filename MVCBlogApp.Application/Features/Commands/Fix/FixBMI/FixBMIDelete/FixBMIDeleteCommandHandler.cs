using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Fix.FixBMI.FixBMIDelete
{
    public class FixBMIDeleteCommandHandler : IRequestHandler<FixBMIDeleteCommandRequest, FixBMIDeleteCommandResponse>
    {
        private readonly IFixService _fixService;

        public FixBMIDeleteCommandHandler(IFixService fixService)
        {
            _fixService = fixService;
        }

        public async Task<FixBMIDeleteCommandResponse> Handle(FixBMIDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _fixService.FixBMIDeleteAsync(request.Id);
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
