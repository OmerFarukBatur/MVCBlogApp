using MediatR;

namespace MVCBlogApp.Application.Features.Queries.Blog.GetAllBlog
{
    public class GetAllBlogQueryRequest : IRequest<GetAllBlogQueryResponse>
    {
    }
}