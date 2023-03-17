using MediatR;

namespace MVCBlogApp.Application.Features.Commands.News.NewsPaper.NewsPaperUpdate
{
    public class NewsPaperUpdateCommandRequest : IRequest<NewsPaperUpdateCommandResponse>
    {
        public int Id { get; set; }
        public string NewsPaperName { get; set; }
        public int StatusId { get; set; }
        public int LangId { get; set; }
    }
}