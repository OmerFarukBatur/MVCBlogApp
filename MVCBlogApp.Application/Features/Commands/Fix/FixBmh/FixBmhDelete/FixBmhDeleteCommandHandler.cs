using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Fix.FixBmh.FixBmhDelete
{
    public class FixBmhDeleteCommandHandler : IRequestHandler<FixBmhDeleteCommandRequest, FixBmhDeleteCommandResponse>
    {
        private readonly IFixService _fixService;

        public FixBmhDeleteCommandHandler(IFixService fixService)
        {
            _fixService = fixService;
        }

        public async Task<FixBmhDeleteCommandResponse> Handle(FixBmhDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _fixService.FixBmhDeleteAsync(request.Id);
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
