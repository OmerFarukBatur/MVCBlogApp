using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.Article.Article.GetArticleCreateItems
{
    public class GetArticleCreateItemsQueryResponse
    {
        public List<VM_ArticleCategory> ArticleCategories { get; set; }
        public List<VM_Language> Languages { get; set; }
        public List<AllStatus> Statuses { get; set; }
        public List<VM_Navigation> Navigations { get; set; }
    }
}