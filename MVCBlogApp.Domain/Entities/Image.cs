using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class Image : BaseEntity
    {
        public string? Title { get; set; }
        public string? ImageUrl { get; set; }
        public bool? IsCover { get; set; }
        public int? CreateUserID { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? StatusID { get; set; }
        public virtual Status Status { get; set; }
    }
}
