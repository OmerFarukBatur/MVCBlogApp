using MediatR;

namespace MVCBlogApp.Application.Features.Commands.Member.Confession.MemberConfessionCreate
{
    public class MemberConfessionCreateCommandResponse
    {
        public string? Message { get; set; }
        public bool State { get; set; }
    }
}