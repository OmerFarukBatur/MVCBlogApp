using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.UserIslemleri.User.UserUpdate
{
    public class UserUpdateCommandHandler : IRequestHandler<UserUpdateCommandRequest, UserUpdateCommandResponse>
    {
        private readonly IUserIslemleriService _userIslemleriService;

        public UserUpdateCommandHandler(IUserIslemleriService userIslemleriService)
        {
            _userIslemleriService = userIslemleriService;
        }

        public async Task<UserUpdateCommandResponse> Handle(UserUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            UserUpdateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);

            if (validation.IsValid)
            {
                return await _userIslemleriService.UserUpdateAsync(request);
            }
            else
            {
                return new()
                {
                    Message = "Lütfen alanları geçerli değerler ile doldurunuz.",
                    State = false
                };
            }
        }
    }
}
