using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.Calc.CalcPulses.GetAllCalcPulses
{
    public class GetAllCalcPulsesQueryResponse
    {
        public List<VM_CalcPulse> CalcPulses { get; set; }
    }
}