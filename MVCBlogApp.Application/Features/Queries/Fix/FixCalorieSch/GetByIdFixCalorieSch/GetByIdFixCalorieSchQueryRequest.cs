using MediatR;

namespace MVCBlogApp.Application.Features.Queries.Fix.FixCalorieSch.GetByIdFixCalorieSch
{
    public class GetByIdFixCalorieSchQueryRequest : IRequest<GetByIdFixCalorieSchQueryResponse>
    {
        public int Id { get; set; }
    }
}