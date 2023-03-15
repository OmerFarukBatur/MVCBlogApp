using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.File.VideoCategory.GetByIdVideoCategory
{
    public class GetByIdVideoCategoryQueryResponse
    {
        public string? Message { get; set; }
        public bool State { get; set; }
        public VM_VideoCategory? VideoCategory { get; set; }
        public List<VM_Language>? Languages { get; set; }
        public List<AllStatus>? Statuses { get; set; }
    }
}