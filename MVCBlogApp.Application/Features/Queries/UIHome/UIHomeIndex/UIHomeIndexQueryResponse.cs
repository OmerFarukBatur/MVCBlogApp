using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.UIHome.UIHomeIndex
{
    public class UIHomeIndexQueryResponse
    {
        public int LangId { get; set; }
        public VM_TaylanK? TaylanK { get; set; }
    }
}