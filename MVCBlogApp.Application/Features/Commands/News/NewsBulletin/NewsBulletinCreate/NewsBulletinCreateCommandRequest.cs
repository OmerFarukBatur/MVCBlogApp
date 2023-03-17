using MediatR;

namespace MVCBlogApp.Application.Features.Commands.News.NewsBulletin.NewsBulletinCreate
{
    public class NewsBulletinCreateCommandRequest : IRequest<NewsBulletinCreateCommandResponse>
    {
        public string Email { get; set; }
        public int? CreateUserId { get; set; }
        public int StatusId { get; set; }
    }
}