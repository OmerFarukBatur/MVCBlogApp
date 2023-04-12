using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.UserIslemleri.ConsultancyFormType.CFTDelete
{
    public class CFTDeleteCommandHandler : IRequestHandler<CFTDeleteCommandRequest, CFTDeleteCommandResponse>
    {
        private readonly IUserIslemleriService _userIslemleriService;

        public CFTDeleteCommandHandler(IUserIslemleriService userIslemleriService)
        {
            _userIslemleriService = userIslemleriService;
        }

        public async Task<CFTDeleteCommandResponse> Handle(CFTDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _userIslemleriService.CFTDeleteAsync(request.Id);
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
