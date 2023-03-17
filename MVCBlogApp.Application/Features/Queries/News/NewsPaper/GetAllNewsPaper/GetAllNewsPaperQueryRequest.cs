using MediatR;

namespace MVCBlogApp.Application.Features.Queries.News.NewsPaper.GetAllNewsPaper
{
    public class GetAllNewsPaperQueryRequest : IRequest<GetAllNewsPaperQueryResponse>
    {
    }
}