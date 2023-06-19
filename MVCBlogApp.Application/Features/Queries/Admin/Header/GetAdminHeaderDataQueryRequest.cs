using MediatR;

namespace MVCBlogApp.Application.Features.Queries.Admin.Header
{
    public class GetAdminHeaderDataQueryRequest : IRequest<GetAdminHeaderDataQueryResponse>
    {
        public int Id { get; set; }
    }
}