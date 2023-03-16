namespace MVCBlogApp.Application.ViewModels
{
    public class VM_Video
    {
        public int? Id { get; set; }
        public int? VideoCategoryId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? VideoUrl { get; set; }
        public string? VideoEmbedCode { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? CreateUserId { get; set; }
        public int? StatusId { get; set; }
        public int? LangId { get; set; }

        public string? Language { get; set; }
        public string? StatusName { get; set; }
        public string? VideoCategoryName { get; set; }
    }
}
