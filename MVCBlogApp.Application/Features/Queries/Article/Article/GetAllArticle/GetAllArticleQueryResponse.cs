using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.Article.Article.GetAllArticle
{
    public class GetAllArticleQueryResponse
    {
        public List<VM_Article> Articles { get; set; }
    }
}