using MediatR;

namespace MVCBlogApp.Application.Features.Queries.ReferenceAndOuther.PressType.GetByIdPressType
{
    public class GetByIdPressTypeQueryRequest : IRequest<GetByIdPressTypeQueryResponse>
    {
        public int Id { get; set; }
    }
}