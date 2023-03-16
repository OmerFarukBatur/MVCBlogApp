using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.File.Video.GetVideoCreateItems
{
    public class GetVideoCreateItemsQueryResponse
    {
        public List<VM_VideoCategory> VideoCategories { get; set; }
        public List<VM_Language> Languages { get; set; }
        public List<AllStatus> Statuses { get; set; }
    }
}