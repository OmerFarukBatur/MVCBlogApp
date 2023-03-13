using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.Result.ResultBMIs.GetAllResultBMI
{
    public class GetAllResultBMIQueryResponse
    {
        public List<VM_ResultBMI> ResultBMIs { get; set; }
    }
}