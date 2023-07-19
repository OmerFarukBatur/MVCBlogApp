using MediatR;

namespace MVCBlogApp.Application.Features.Commands.IUHome.Danisan
{
    public class DanisanConfessionCreateCommandRequest : IRequest<DanisanConfessionCreateCommandResponse>
    {
        public string MemberName { get; set; }
        public string MemberConfession { get; set; }
        public bool IsVisible { get; set; }
    }
}