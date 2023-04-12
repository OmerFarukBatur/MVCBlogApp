using MediatR;

namespace MVCBlogApp.Application.Features.Queries.UserIslemleri.Confession.GetByIdConfession
{
    public class GetByIdConfessionQueryRequest : IRequest<GetByIdConfessionQueryResponse>
    {
        public int Id { get; set; }
    }
}