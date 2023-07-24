using MediatR;

namespace MVCBlogApp.Application.Features.Queries.UIBlog.BlogCategoryIndex
{
    public class BlogCategoryIndexQueryRequest : IRequest<BlogCategoryIndexQueryResponse>
    {
        public string catName { get; set; }
    }
}