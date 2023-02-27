using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class Image : BaseEntity
    {
        public string? Title { get; set; }
        public string? ImageUrl { get; set; }
        public bool? IsCover { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? CreateUserId { get; set; }
        public int? StatusId { get; set; }
        public int? LangId { get; set; }
    }
}
