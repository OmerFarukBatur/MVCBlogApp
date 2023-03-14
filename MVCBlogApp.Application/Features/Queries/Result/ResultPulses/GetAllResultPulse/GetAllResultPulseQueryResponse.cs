using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.Result.ResultPulses.GetAllResultPulse
{
    public class GetAllResultPulseQueryResponse
    {
        public List<VM_ResultPulse> ResultPulses { get; set; }
    }
}