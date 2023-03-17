using MediatR;

namespace MVCBlogApp.Application.Features.Queries.News.NewsBulletin.GetByIdNews
{
    public class GetByIdNewsQueryRequest : IRequest<GetByIdNewsQueryResponse>
    {
        public int Id { get; set; }
    }
}