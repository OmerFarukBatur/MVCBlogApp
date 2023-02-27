using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class VideoCategory : BaseEntity
    {
        public VideoCategory()
        {
            Videos = new HashSet<Video>();
        }

        public string? VideoCategoryName { get; set; }
        public int? StatusId { get; set; }
        public int? LangId { get; set; }

        public virtual ICollection<Video> Videos { get; set; }
    }
}
