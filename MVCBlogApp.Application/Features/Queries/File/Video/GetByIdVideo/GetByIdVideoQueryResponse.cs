using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.File.Video.GetByIdVideo
{
    public class GetByIdVideoQueryResponse
    {
        public string? Message { get; set; }
        public bool State { get; set; }
        public VM_Video? Video { get; set; }
        public List<VM_VideoCategory>? VideoCategories { get; set; }
        public List<VM_Language>? Languages { get; set; }
        public List<AllStatus>? Statuses { get; set; }
    }
}