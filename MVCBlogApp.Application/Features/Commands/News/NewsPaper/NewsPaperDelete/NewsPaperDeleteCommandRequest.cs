using MediatR;

namespace MVCBlogApp.Application.Features.Commands.News.NewsPaper.NewsPaperDelete
{
    public class NewsPaperDeleteCommandRequest : IRequest<NewsPaperDeleteCommandResponse>
    {
        public int Id { get; set; }
    }
}