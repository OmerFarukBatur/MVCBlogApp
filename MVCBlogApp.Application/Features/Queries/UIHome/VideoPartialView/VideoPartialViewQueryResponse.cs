using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.UIHome.VideoPartialView
{
    public class VideoPartialViewQueryResponse
    {
        public PagedResult<VM_Video> Result { get; set; }
    }
}