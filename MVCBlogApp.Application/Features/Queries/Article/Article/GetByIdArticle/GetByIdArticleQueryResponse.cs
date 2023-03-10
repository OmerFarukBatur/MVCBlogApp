using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.Article.Article.GetByIdArticle
{
    public class GetByIdArticleQueryResponse
    {
        public VM_Article? Article { get; set; }
        public List<VM_ArticleCategory>? ArticleCategories { get; set; }
        public List<VM_Language>? Languages { get; set; }
        public List<AllStatus>? Statuses { get; set; }
        public List<VM_Navigation>? Navigations { get; set; }
        public string? Message { get; set; }
        public bool State { get; set; }
    }
}