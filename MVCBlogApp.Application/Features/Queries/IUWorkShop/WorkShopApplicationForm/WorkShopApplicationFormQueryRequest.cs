using MediatR;

namespace MVCBlogApp.Application.Features.Queries.IUWorkShop.WorkShopApplicationForm
{
    public class WorkShopApplicationFormQueryRequest : IRequest<WorkShopApplicationFormQueryResponse>
    {
        public int id { get; set; }
    }
}