using MediatR;

namespace MVCBlogApp.Application.Features.Queries.Workshop.WorkshopCategory.GetByIdWorkshopCategory
{
    public class GetByIdWorkshopCategoryQueryRequest : IRequest<GetByIdWorkshopCategoryQueryResponse>
    {
        public int Id { get; set; }
    }
}