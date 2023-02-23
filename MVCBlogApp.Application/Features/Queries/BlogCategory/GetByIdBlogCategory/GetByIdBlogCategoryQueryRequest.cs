using MediatR;

namespace MVCBlogApp.Application.Features.Queries.BlogCategory.GetByIdBlogCategory
{
    public class GetByIdBlogCategoryQueryRequest : IRequest<GetByIdBlogCategoryQueryResponse>
    {
        public int Id { get; set; }
    }
}