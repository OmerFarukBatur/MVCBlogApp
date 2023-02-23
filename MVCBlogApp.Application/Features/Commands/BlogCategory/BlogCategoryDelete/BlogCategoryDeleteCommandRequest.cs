using MediatR;

namespace MVCBlogApp.Application.Features.Commands.BlogCategory.BlogCategoryDelete
{
    public class BlogCategoryDeleteCommandRequest : IRequest<BlogCategoryDeleteCommandResponse>
    {
        public int Id { get; set; }
    }
}