using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class Video : BaseEntity
    {
        public int? VideoCategoryId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? VideoUrl { get; set; }
        public string? VideoEmbedCode { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? CreateUserId { get; set; }
        public int? StatusId { get; set; }
        public int? LangId { get; set; }

        public virtual VideoCategory? VideoCategory { get; set; }
    }
}
