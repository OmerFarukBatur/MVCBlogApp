namespace MVCBlogApp.Application.ViewModels
{
    public class VM_Banner
    {
        public int? Id { get; set; }
        public string? BannerName { get; set; }
        public string? BannerUrl { get; set; }
        public int? BannerOrder { get; set; }
        public int? Type { get; set; }
        public int? StatusId { get; set; }
        public string? DateString { get; set; }
        public int? LangId { get; set; }

        public string? Language { get; set; }
        public string? StatusName { get; set; }
    }
}
