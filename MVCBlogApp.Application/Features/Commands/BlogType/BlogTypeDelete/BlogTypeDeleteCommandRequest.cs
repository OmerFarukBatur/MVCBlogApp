using MediatR;

namespace MVCBlogApp.Application.Features.Commands.BlogType.BlogTypeDelete
{
    public class BlogTypeDeleteCommandRequest : IRequest<BlogTypeDeleteCommandResponse>
    {
        public int Id { get; set; }
    }
}