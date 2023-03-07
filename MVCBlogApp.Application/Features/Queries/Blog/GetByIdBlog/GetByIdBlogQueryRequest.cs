using MediatR;

namespace MVCBlogApp.Application.Features.Queries.Blog.GetByIdBlog
{
    public class GetByIdBlogQueryRequest : IRequest<GetByIdBlogQueryResponse>
    {
        public int Id { get; set; }
    }
}