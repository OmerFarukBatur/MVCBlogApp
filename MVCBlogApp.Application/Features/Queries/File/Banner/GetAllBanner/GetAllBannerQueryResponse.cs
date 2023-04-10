using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.File.Banner.GetAllBanner
{
    public class GetAllBannerQueryResponse
    {
        public List<VM_Banner> Banners { get; set; }
    }
}