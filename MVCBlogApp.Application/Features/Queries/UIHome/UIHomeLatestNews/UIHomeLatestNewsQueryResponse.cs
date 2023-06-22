using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.UIHome.UIHomeLatestNews
{
    public class UIHomeLatestNewsQueryResponse
    {
        public List<VM_LatestNew> LatestNews { get; set; }
        public int LangId { get; set; }
    }
}