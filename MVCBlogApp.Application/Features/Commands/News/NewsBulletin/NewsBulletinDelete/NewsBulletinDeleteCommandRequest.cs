using MediatR;

namespace MVCBlogApp.Application.Features.Commands.News.NewsBulletin.NewsBulletinDelete
{
    public class NewsBulletinDeleteCommandRequest : IRequest<NewsBulletinDeleteCommandResponse>
    {
        public int Id { get; set; }
    }
}