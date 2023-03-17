using MediatR;

namespace MVCBlogApp.Application.Features.Commands.News.NewsPaper.NewsPaperCreate
{
    public class NewsPaperCreateCommandRequest : IRequest<NewsPaperCreateCommandResponse>
    {
        public string NewsPaperName { get; set; }
        public int StatusId { get; set; }
        public int LangId { get; set; }
    }
}