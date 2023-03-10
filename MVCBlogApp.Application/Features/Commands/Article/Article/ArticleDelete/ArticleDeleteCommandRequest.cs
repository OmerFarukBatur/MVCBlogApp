using MediatR;

namespace MVCBlogApp.Application.Features.Commands.Article.Article.ArticleDelete
{
    public class ArticleDeleteCommandRequest : IRequest<ArticleDeleteCommandResponse>
    {
        public int Id { get; set; }
    }
}