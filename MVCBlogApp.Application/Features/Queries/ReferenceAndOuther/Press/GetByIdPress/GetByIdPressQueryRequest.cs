using MediatR;

namespace MVCBlogApp.Application.Features.Queries.ReferenceAndOuther.Press.GetByIdPress
{
    public class GetByIdPressQueryRequest : IRequest<GetByIdPressQueryResponse>
    {
        public int Id { get; set; }
    }
}