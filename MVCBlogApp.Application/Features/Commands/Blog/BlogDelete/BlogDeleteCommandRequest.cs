using MediatR;

namespace MVCBlogApp.Application.Features.Commands.Blog.BlogDelete
{
    public class BlogDeleteCommandRequest : IRequest<BlogDeleteCommandResponse>
    {
        public int Id { get; set; }
    }
}