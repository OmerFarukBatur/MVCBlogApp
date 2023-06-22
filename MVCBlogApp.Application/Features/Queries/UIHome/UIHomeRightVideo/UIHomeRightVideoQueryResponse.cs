using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.UIHome.UIHomeRightVideo
{
    public class UIHomeRightVideoQueryResponse
    {
        public VM_Video? Video { get; set; }
        public int LangId { get; set; }
    }
}