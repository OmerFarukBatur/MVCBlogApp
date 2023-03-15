using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.File.VideoCategory.GetAllVideoCategory
{
    public class GetAllVideoCategoryQueryResponse 
    {
        public List<VM_VideoCategory> VideoCategories { get; set; }
    }
}