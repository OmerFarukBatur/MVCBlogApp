using MediatR;

namespace MVCBlogApp.Application.Features.Commands.Article.ArticleCategory.ArticleCategoryDelete
{
    public class ArticleCategoryDeleteCommandRequest : IRequest<ArticleCategoryDeleteCommandResponse>
    {
        public int Id { get; set; } 
    }
}