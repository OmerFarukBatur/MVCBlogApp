using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.Result.ResultBMIs.GetByIdResultBMI
{
    public class GetByIdResultBMIQueryResponse
    {
        public string? Message { get; set; }
        public bool State { get; set; }
        public VM_ResultBMI? ResultBMI { get; set; }
    }
}