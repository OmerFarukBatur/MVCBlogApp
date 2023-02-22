using MediatR;

namespace MVCBlogApp.Application.Features.Queries.BlogType.GetByIdBlogType
{
    public class GetByIdBlogTypeQueryRequest : IRequest<GetByIdBlogTypeQueryResponse>
    {
        public int Id { get; set; }
    }
}