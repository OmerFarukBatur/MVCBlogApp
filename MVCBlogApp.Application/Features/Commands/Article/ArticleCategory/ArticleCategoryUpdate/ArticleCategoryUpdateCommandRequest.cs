using MediatR;

namespace MVCBlogApp.Application.Features.Commands.Article.ArticleCategory.ArticleCategoryUpdate
{
    public class ArticleCategoryUpdateCommandRequest : IRequest<ArticleCategoryUpdateCommandResponse>
    {
        public int Id { get; set; }
        public string MetaTitle { get; set; }
        public string MetaKey { get; set; }
        public string MetaDescription { get; set; }
        public string CategoryName { get; set; }
        public int? ParentId { get; set; }
        public int StatusId { get; set; }
        public int LangId { get; set; }
    }
}