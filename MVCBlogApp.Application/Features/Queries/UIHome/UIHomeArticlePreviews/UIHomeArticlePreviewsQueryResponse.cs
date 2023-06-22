using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.UIHome.UIHomeArticlePreviews
{
    public class UIHomeArticlePreviewsQueryResponse
    {
        public List<VM_Navigation> Articles { get; set; }
        public int LangId { get; set; }
    }
}