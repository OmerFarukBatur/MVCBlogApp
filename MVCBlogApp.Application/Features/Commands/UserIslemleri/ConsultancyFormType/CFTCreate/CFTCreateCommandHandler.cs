using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.UserIslemleri.ConsultancyFormType.CFTCreate
{
    public class CFTCreateCommandHandler : IRequestHandler<CFTCreateCommandRequest, CFTCreateCommandResponse>
    {
        private readonly IUserIslemleriService _userIslemleriService;

        public CFTCreateCommandHandler(IUserIslemleriService userIslemleriService)
        {
            _userIslemleriService = userIslemleriService;
        }

        public async Task<CFTCreateCommandResponse> Handle(CFTCreateCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.ConsultancyFormTypeName != "" && request.ConsultancyFormTypeName.Length > 0 && request.ConsultancyFormTypeName.Length < 251) 
            {
                return await _userIslemleriService.CFTCreateAsync(request);
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
