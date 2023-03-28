using MediatR;

namespace MVCBlogApp.Application.Features.Queries.ReferenceAndOuther.SeminarVisuals.GetByIdSeminarVisual
{
    public class GetByIdSeminarVisualQueryRequest : IRequest<GetByIdSeminarVisualQueryResponse>
    {
        public int Id { get; set; }
    }
}