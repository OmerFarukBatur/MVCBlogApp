using MediatR;

namespace MVCBlogApp.Application.Features.Commands.Article.ArticleCategory.ArticleCategoryCreate
{
    public class ArticleCategoryCreateCommandRequest : IRequest<ArticleCategoryCreateCommandResponse>
    {
       public string MetaTitle { get; set; }
        public string MetaKey { get; set; }
        public string MetaDescription { get; set; }
        public string CategoryName { get; set; }
        public int? ParentId { get; set; }
        public int? CreateUserId { get; set; }
        public int StatusId { get; set; }
        public int LangId { get; set; }
    }
}