using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Fix.FixOptimum.FixOptimumDelete
{
    public class FixOptimumDeleteCommandHandler : IRequestHandler<FixOptimumDeleteCommandRequest, FixOptimumDeleteCommandResponse>
    {
        private readonly IFixService _fixService;

        public FixOptimumDeleteCommandHandler(IFixService fixService)
        {
            _fixService = fixService;
        }

        public async Task<FixOptimumDeleteCommandResponse> Handle(FixOptimumDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _fixService.FixOptimumDeleteAsync(request.Id);
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
