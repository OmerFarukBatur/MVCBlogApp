using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Home.PasswordReset
{
    public class PasswordResetCommandHandler : IRequestHandler<PasswordResetCommandRequest, PasswordResetCommandResponse>
    {
        private readonly IAuthService _authService;

        public PasswordResetCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<PasswordResetCommandResponse> Handle(PasswordResetCommandRequest request, CancellationToken cancellationToken)
        {
            PasswordResetCommandValidator validations = new();
            ValidationResult result = validations.Validate(request);

            if (result.IsValid)
            {
                return await _authService.ByIdUserPasswordReset(request);
            }
            else
            {
                return new PasswordResetCommandResponse() { Status = false };
            }
        }
    }
}
