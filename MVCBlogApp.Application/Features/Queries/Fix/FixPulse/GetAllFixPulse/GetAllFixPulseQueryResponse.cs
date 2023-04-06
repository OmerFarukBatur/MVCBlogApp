using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.Fix.FixPulse.GetAllFixPulse
{
    public class GetAllFixPulseQueryResponse
    {
        public List<VM_FixPulse> FixPulses { get; set; }
    }
}