using MediatR;

namespace MVCBlogApp.Application.Features.Commands.UserIslemleri.Confession.ConfessionCreate
{
    public class ConfessionCreateCommandRequest : IRequest<ConfessionCreateCommandResponse>
    {
        public string MemberConfession { get; set; }
        public string MemberName { get; set; }
        public bool IsVisible { get; set; }
        public bool IsAprove { get; set; }
        public bool IsRead { get; set; }
        public int StatusId { get; set; }
        public int LangId { get; set; }
    }
}