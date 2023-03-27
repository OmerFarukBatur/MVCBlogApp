namespace MVCBlogApp.Application.ViewModels
{
    public class VM_References
    {
        public int? Id { get; set; }
        public string? Title { get; set; }
        public string? UrlLink { get; set; }
        public string? ImgUrl { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? CreateUserId { get; set; }
        public int? StatusId { get; set; }

        public string? StatusName { get; set; }
    }
}
