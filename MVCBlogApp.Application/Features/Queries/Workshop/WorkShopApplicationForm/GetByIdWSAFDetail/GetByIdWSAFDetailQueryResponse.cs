using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.Workshop.WorkShopApplicationForm.GetByIdWSAFDetail
{
    public class GetByIdWSAFDetailQueryResponse
    {
        public string? Message { get; set; }
        public bool State { get; set; }
        public VM_WorkShopApplicationForm? WorkShopApplicationForm { get; set; }
    }
}