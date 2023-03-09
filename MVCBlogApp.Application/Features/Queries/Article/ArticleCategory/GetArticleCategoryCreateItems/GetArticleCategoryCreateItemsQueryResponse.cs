using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.Article.ArticleCategory.GetArticleCategoryCreateItems
{
    public class GetArticleCategoryCreateItemsQueryResponse
    {
        public List<VM_ArticleCategory> ArticleCategories { get; set; }
        public List<VM_Language> Languages { get; set; }
        public List<AllStatus> Statuses { get; set; }
    }
}