using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.Fix.FixFeedPyramid.GetAllFixFeedPyramid
{
    public class GetAllFixFeedPyramidQueryResponse
    {
        public List<VM_FixFeedPyramid> FixFeedPyramids { get; set; }
    }
}