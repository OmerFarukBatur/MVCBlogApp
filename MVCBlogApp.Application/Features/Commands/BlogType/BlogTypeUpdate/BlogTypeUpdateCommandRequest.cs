using MediatR;

namespace MVCBlogApp.Application.Features.Commands.BlogType.BlogTypeUpdate
{
    public class BlogTypeUpdateCommandRequest : IRequest<BlogTypeUpdateCommandResponse>
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
        public int LangId { get; set; }
    }
}