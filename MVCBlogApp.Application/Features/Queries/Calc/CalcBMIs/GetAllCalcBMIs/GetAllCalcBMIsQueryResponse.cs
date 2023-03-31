using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.Calc.CalcBMIs.GetAllCalcBMIs
{
    public class GetAllCalcBMIsQueryResponse
    {
        public List<VM_CalcBMI> CalcBMIs { get; set; }
    }
}