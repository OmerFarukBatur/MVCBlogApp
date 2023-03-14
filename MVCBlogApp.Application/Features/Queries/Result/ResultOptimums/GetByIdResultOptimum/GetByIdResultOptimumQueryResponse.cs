using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.Result.ResultOptimums.GetByIdResultOptimum
{
    public class GetByIdResultOptimumQueryResponse
    {
        public string? Message { get; set; }
        public bool State { get; set; }
        public VM_ResultOptimum? ResultOptimum { get; set; }
    }
}