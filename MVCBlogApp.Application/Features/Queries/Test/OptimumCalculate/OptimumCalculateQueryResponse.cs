using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.Test.OptimumCalculate
{
    public class OptimumCalculateQueryResponse
    {
        public VM_Optimum Optimum { get; set; }
        public List<VM_Gender> Genders { get; set; }
    }
}