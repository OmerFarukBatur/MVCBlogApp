using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class VideoCategory : BaseEntity
    {
        public string? VideoCategoryName { get; set; }
        public int? StatusID { get; set; }
        public virtual Status Status { get; set; }
        public virtual IList<Video> Videos { get; set; }
    }
}
