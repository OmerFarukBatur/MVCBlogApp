using MediatR;

namespace MVCBlogApp.Application.Features.Commands.News.NewsBulletin.NewsBulletinUpdate
{
    public class NewsBulletinUpdateCommandRequest : IRequest<NewsBulletinUpdateCommandResponse>
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public int StatusId { get; set; }
    }
}