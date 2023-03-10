using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.Result.ResultBMhs.GetByIdResultBMhs
{
    public class GetByIdResultBMhsQueryResponse
    {
        public string? Message { get; set; }
        public bool State { get; set; }
        public VM_ResultBMhs? ResultBMhs { get; set; }
    }
}