using MediatR;

namespace MVCBlogApp.Application.Features.Commands.UserIslemleri.Confession.ConfessionUpdate
{
    public class ConfessionUpdateCommandRequest : IRequest<ConfessionUpdateCommandResponse>
    {
        public int Id { get; set; }
        public string MemberConfession { get; set; }
        public string MemberName { get; set; }
        public bool IsVisible { get; set; }
        public bool IsAprove { get; set; }
        public bool IsRead { get; set; }
        public int StatusId { get; set; }
        public int LangId { get; set; }
    }
}