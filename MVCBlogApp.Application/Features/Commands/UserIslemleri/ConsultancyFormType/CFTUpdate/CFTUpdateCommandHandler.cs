using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.UserIslemleri.ConsultancyFormType.CFTUpdate
{
    public class CFTUpdateCommandHandler : IRequestHandler<CFTUpdateCommandRequest, CFTUpdateCommandResponse>
    {
        private readonly IUserIslemleriService _userIslemleriService;

        public CFTUpdateCommandHandler(IUserIslemleriService userIslemleriService)
        {
            _userIslemleriService = userIslemleriService;
        }

        public async Task<CFTUpdateCommandResponse> Handle(CFTUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.ConsultancyFormTypeName != "" && request.ConsultancyFormTypeName.Length > 0 && request.ConsultancyFormTypeName.Length < 251)
            {
                return await _userIslemleriService.CFTUpdateAsync(request);
            }
            else
            {
                return new()
                {
                    Message = "Lütfen alanları geçerli değerlerle doldurunzu.",
                    State = false
                };
            }
        }
    }
}
