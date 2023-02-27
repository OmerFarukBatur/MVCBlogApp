using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class References : BaseEntity
    {
        public string? Title { get; set; }
        public string? UrlLink { get; set; }
        public string? ImgUrl { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? CreateUserId { get; set; }
        public int? StatusId { get; set; }
    }
}
