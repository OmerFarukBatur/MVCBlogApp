using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.UIHome.ConfessionsPartialView
{
    public class ConfessionsPartialViewQueryResponse
    {
        public PagedResult<VM_Confession> Result { get; set; }
    }
}