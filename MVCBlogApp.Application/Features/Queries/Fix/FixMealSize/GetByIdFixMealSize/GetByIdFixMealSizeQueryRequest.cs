using MediatR;

namespace MVCBlogApp.Application.Features.Queries.Fix.FixMealSize.GetByIdFixMealSize
{
    public class GetByIdFixMealSizeQueryRequest : IRequest<GetByIdFixMealSizeQueryResponse>
    {
        public int Id { get; set; }
    }
}