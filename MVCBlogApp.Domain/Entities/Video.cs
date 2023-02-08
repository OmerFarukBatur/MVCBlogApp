using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class Video : BaseEntity
    {
        public int? VideoCategoryID { get; set; }
        public string Title { get; set; }
        public string VideoUrl { get; set; }
        public string VideoEmbedCode { get; set; }

        public string Description { get; set; }
        public int? LangID { get; set; }

        public int? StatusID { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? CreateUserID { get; set; }
        public virtual Languages Languages { get; set; }
        public virtual Status Status { get; set; }
        public virtual VideoCategory VideoCategory { get; set; }
    }
}
