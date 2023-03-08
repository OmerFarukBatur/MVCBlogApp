using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.UserIslemleri.User.UserDelete
{
    public class UserDeleteCommandHandler : IRequestHandler<UserDeleteCommandRequest, UserDeleteCommandResponse>
    {
        private readonly IUserIslemleriService _userIslemleriService;

        public UserDeleteCommandHandler(IUserIslemleriService userIslemleriService)
        {
            _userIslemleriService = userIslemleriService;
        }

        public async Task<UserDeleteCommandResponse> Handle(UserDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _userIslemleriService.UserDeleteAsync(request.Id);
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
