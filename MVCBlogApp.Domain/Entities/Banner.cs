using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class Banner : BaseEntity
    {
        public string? BannerName { get; set; }
        public string? BannerUrl { get; set; }
        public int? BannerOrder { get; set; }
        public int? Type { get; set; }
        public int? StatusId { get; set; }
        public string? DateString { get; set; }
        public int? LangId { get; set; }
    }
}
