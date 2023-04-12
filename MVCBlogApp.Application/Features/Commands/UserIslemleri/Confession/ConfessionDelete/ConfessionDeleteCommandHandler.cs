using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.UserIslemleri.Confession.ConfessionDelete
{
    public class ConfessionDeleteCommandHandler : IRequestHandler<ConfessionDeleteCommandRequest, ConfessionDeleteCommandResponse>
    {
        private readonly IUserIslemleriService _userIslemleriService;

        public ConfessionDeleteCommandHandler(IUserIslemleriService userIslemleriService)
        {
            _userIslemleriService = userIslemleriService;
        }

        public async Task<ConfessionDeleteCommandResponse> Handle(ConfessionDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _userIslemleriService.ConfessionDeleteAsync(request.Id);
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
