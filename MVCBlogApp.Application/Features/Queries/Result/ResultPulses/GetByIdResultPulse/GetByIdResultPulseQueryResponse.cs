using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.Result.ResultPulses.GetByIdResultPulse
{
    public class GetByIdResultPulseQueryResponse
    {
        public VM_ResultPulse? ResultPulse { get; set; }
        public string? Message { get; set; }
        public bool State { get; set; }
    }
}