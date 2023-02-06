using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class ImageCarousel : BaseEntity
    {
        public int CarouselID { get; set; }
        public string ImgName { get; set; }
        public string ImgUrl { get; set; }
        public int StatusID { get; set; }
        public virtual Carousel Carousel { get; set; }
    }
}
