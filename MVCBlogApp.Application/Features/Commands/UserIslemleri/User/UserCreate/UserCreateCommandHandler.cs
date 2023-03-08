using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.UserIslemleri.User.UserCreate
{
    public class UserCreateCommandHandler : IRequestHandler<UserCreateCommandRequest, UserCreateCommandResponse>
    {
        private readonly IUserIslemleriService _userIslemleriService;

        public UserCreateCommandHandler(IUserIslemleriService userIslemleriService)
        {
            _userIslemleriService = userIslemleriService;
        }

        public async Task<UserCreateCommandResponse> Handle(UserCreateCommandRequest request, CancellationToken cancellationToken)
        {
            UserCreateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);

            if (validation.IsValid)
            {
                return await _userIslemleriService.UserCreateAsync(request);
            }
            else
            {
                return new()
                {
                    Message = "Lütfen alanları geçerli değerlerle doldurunuz.",
                    State = false
                };
            }
        }
    }
}
