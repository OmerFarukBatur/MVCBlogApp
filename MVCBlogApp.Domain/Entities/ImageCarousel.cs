using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class ImageCarousel : BaseEntity
    {
        public int? CarouselId { get; set; }
        public string? ImgName { get; set; }
        public string? ImgUrl { get; set; }
        public int? StatusId { get; set; }
    }
}
