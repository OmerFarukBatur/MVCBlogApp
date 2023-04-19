using MediatR;

namespace MVCBlogApp.Application.Features.Queries.Workshop.Workshop.GetByIdWorkshop
{
    public class GetByIdWorkshopQueryRequest : IRequest<GetByIdWorkshopQueryResponse>
    {
        public int Id { get; set; }
    }
}