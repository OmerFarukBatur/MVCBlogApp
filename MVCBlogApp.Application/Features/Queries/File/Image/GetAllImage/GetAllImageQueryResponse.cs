using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.File.Image.GetAllImage
{
    public class GetAllImageQueryResponse
    {
        public List<VM_Image> Images { get; set; }
    }
}