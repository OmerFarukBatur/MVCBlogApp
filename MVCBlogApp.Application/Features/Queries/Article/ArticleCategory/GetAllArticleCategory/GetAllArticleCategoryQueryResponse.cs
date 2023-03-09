using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.Article.ArticleCategory.GetAllArticleCategory
{
    public class GetAllArticleCategoryQueryResponse
    {
        public List<VM_ArticleCategory> ArticleCategories { get; set; }
    }
}