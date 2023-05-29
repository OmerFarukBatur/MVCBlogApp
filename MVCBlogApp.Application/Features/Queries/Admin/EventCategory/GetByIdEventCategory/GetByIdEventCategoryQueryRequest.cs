using MediatR;

namespace MVCBlogApp.Application.Features.Queries.Admin.EventCategory.GetByIdEventCategory
{
    public class GetByIdEventCategoryQueryRequest : IRequest<GetByIdEventCategoryQueryResponse>
    {
        public int Id { get; set; }
    }
}