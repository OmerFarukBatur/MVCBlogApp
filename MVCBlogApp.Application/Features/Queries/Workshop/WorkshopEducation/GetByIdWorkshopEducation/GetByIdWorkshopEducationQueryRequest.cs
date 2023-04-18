using MediatR;

namespace MVCBlogApp.Application.Features.Queries.Workshop.WorkshopEducation.GetByIdWorkshopEducation
{
    public class GetByIdWorkshopEducationQueryRequest : IRequest<GetByIdWorkshopEducationQueryResponse>
    {
        public int Id { get; set; }
    }
}