using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.File.Video.GetAllVideo
{
    public class GetAllVideoQueryResponse
    {
        public List<VM_Video> Videos { get; set; }
    }
}