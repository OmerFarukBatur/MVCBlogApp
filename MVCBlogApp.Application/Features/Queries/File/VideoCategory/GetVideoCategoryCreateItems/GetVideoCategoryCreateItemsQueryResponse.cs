using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.File.VideoCategory.GetVideoCategoryCreateItems
{
    public class GetVideoCategoryCreateItemsQueryResponse
    {
        public List<VM_Language> Languages { get; set; }
        public List<AllStatus> Statuses { get; set; }
    }
}