using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.Calc.CalcBmhs.GetAllCalcBmhs
{
    public class GetAllCalcBmhsQueryResponse
    {
        public List<VM_CalcBmh> CalcBmhs { get; set; }
    }
}