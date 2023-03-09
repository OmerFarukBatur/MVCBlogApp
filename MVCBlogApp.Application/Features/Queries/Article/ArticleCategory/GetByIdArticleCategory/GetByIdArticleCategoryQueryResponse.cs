using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.Article.ArticleCategory.GetByIdArticleCategory
{
    public class GetByIdArticleCategoryQueryResponse
    {
        public string? Message { get; set; }
        public bool State { get; set; }
        public VM_ArticleCategory? ArticleCategory { get; set; }
        public List<VM_ArticleCategory>? ArticleCategories { get; set; }
        public List<VM_Language>? Languages { get; set; }
        public List<AllStatus>? Statuses { get; set; }
    }
}