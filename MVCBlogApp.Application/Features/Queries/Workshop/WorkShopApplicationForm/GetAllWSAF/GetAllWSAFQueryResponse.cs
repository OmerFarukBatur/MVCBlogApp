using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.Workshop.WorkShopApplicationForm.GetAllWSAF
{
    public class GetAllWSAFQueryResponse
    {
        public List<VM_WorkShopApplicationForm> WorkShopApplicationForms { get; set; }
    }
}