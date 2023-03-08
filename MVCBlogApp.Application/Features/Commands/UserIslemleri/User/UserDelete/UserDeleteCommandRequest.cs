using MediatR;

namespace MVCBlogApp.Application.Features.Commands.UserIslemleri.User.UserDelete
{
    public class UserDeleteCommandRequest : IRequest<UserDeleteCommandResponse>
    {
        public int Id { get; set; }
    }
}