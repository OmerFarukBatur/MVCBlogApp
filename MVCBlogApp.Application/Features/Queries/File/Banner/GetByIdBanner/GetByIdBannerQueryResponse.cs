using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.File.Banner.GetByIdBanner
{
    public class GetByIdBannerQueryResponse
    {
        public string? Message { get; set; }
        public bool State { get; set; }
        public VM_Banner? Banner { get; set; }
        public List<VM_Language>? Languages { get; set; }
        public List<AllStatus>? Statuses { get; set; }
    }
}