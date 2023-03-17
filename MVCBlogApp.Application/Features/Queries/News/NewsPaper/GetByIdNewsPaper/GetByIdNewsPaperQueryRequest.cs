using MediatR;

namespace MVCBlogApp.Application.Features.Queries.News.NewsPaper.GetByIdNewsPaper
{
    public class GetByIdNewsPaperQueryRequest : IRequest<GetByIdNewsPaperQueryResponse>
    {
        public int Id { get; set; }
    }
}