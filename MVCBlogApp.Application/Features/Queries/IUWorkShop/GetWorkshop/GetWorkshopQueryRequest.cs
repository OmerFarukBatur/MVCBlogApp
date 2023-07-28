using MediatR;

namespace MVCBlogApp.Application.Features.Queries.IUWorkShop.GetWorkshop
{
    public class GetWorkshopQueryRequest : IRequest<GetWorkshopQueryResponse>
    {
        public int WsEducationID { get; set; }
    }
}