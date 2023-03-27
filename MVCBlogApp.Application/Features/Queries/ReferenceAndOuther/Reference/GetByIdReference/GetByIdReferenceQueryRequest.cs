using MediatR;

namespace MVCBlogApp.Application.Features.Queries.ReferenceAndOuther.Reference.GetByIdReference
{
    public class GetByIdReferenceQueryRequest : IRequest<GetByIdReferenceQueryResponse>
    {
        public int Id { get; set; }
    }
}