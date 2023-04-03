using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.Fix.FixBmh.GetAllFixBmhs
{
    public class GetAllFixBmhsQueryResponse
    {
        public List<VM_FixBmh> FixBmhs { get; set; }
    }
}