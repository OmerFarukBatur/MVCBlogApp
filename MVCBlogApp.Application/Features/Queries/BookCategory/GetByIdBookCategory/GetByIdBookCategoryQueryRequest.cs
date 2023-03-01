using MediatR;

namespace MVCBlogApp.Application.Features.Queries.BookCategory.GetByIdBookCategory
{
    public class GetByIdBookCategoryQueryRequest : IRequest<GetByIdBookCategoryQueryResponse>
    {
        public int Id { get; set; }
    }
}