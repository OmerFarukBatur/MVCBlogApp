using MediatR;

namespace MVCBlogApp.Application.Features.Queries.Fix.FixBmh.GetByIdFixBmh
{
    public class GetByIdFixBmhQueryRequest : IRequest<GetByIdFixBmhQueryResponse>
    {
        public int Id { get; set; }
    }
}