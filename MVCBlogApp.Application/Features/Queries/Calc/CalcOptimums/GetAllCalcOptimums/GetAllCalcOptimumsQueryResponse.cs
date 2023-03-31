using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.Calc.CalcOptimums.GetAllCalcOptimums
{
    public class GetAllCalcOptimumsQueryResponse
    {
        public List<VM_CalcOptimum> CalcOptimums { get; set; }
    }
}