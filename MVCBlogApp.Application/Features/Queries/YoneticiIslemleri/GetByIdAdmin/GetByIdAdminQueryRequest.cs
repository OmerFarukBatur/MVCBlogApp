using MediatR;

namespace MVCBlogApp.Application.Features.Queries.YoneticiIslemleri.GetByIdAdmin
{
    public class GetByIdAdminQueryRequest : IRequest<GetByIdAdminQueryResponse>
    {
        public int Id { get; set; }
    }
}