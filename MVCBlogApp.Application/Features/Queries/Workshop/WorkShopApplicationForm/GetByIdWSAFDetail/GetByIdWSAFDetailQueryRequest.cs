using MediatR;

namespace MVCBlogApp.Application.Features.Queries.Workshop.WorkShopApplicationForm.GetByIdWSAFDetail
{
    public class GetByIdWSAFDetailQueryRequest : IRequest<GetByIdWSAFDetailQueryResponse>
    {
        public int Id { get; set; }
    }
}