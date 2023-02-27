using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class ImageBlog : BaseEntity
    {
        public int? BlogId { get; set; }
        public bool? IsCover { get; set; }
        public string? ImgName { get; set; }
        public string? ImgUrl { get; set; }
        public int? StatusId { get; set; }
    }
}
