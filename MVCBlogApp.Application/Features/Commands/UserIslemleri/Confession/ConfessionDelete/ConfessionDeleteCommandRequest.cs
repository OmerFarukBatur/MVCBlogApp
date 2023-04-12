using MediatR;

namespace MVCBlogApp.Application.Features.Commands.UserIslemleri.Confession.ConfessionDelete
{
    public class ConfessionDeleteCommandRequest : IRequest<ConfessionDeleteCommandResponse>
    {
        public int Id { get; set; }
    }
}