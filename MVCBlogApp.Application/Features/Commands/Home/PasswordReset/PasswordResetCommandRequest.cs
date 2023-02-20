using MediatR;

namespace MVCBlogApp.Application.Features.Commands.Home.PasswordReset
{
    public class PasswordResetCommandRequest : IRequest<PasswordResetCommandResponse>
    {
        public string Email { get; set; }
    }
}