using MediatR;

namespace MVCBlogApp.Application.Features.Queries.Workshop.WorkshopType.GetByIdWorkshopType
{
    public class GetByIdWorkshopTypeQueryRequest : IRequest<GetByIdWorkshopTypeQueryResponse>
    {
        public int Id { get; set; }
    }
}