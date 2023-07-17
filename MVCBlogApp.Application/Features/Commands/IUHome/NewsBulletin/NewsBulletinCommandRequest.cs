using MediatR;

namespace MVCBlogApp.Application.Features.Commands.IUHome.NewsBulletin
{
    public class NewsBulletinCommandRequest : IRequest<NewsBulletinCommandResponse>
    {
        public string email { get; set; }
    }
}