using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.Fix.FixBMI.GetAllFixBMI
{
    public class GetAllFixBMIQueryResponse
    {
        public List<VM_FixBMI> FixBMIs { get; set; }
    }
}