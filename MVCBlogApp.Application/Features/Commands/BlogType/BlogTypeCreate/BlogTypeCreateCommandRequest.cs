using MediatR;

namespace MVCBlogApp.Application.Features.Commands.BlogType.BlogTypeCreate
{
    public class BlogTypeCreateCommandRequest : IRequest<BlogTypeCreateCommandResponse>
    {
        public string TypeName { get; set; }
        public int LangId { get; set; }
    }
}