using MediatR;

namespace MVCBlogApp.Application.Features.Queries.IUWorkShop.GetWorkshopEducation
{
    public class GetWorkshopEducationQueryRequest : IRequest<GetWorkshopEducationQueryResponse>
    {
        public int WsCategoryID { get; set; }
    }
}