using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.UIPress.MedyaYansimalariPartialView
{
    public class MedyaYansimalariPartialViewQueryResponse
    {
        public PagedResult<VM_Press> Result { get; set; }
    }
}