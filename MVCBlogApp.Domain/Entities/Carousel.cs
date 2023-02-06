using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class Carousel : BaseEntity
    {
        public string Title { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string UrlRoot { get; set; }
        public string TitleClass { get; set; }
        public string ImgName { get; set; }
        public string ImgUrl { get; set; }
        public string Description { get; set; }
        public int? CreateUserID { get; set; }
        public int? StatusID { get; set; }
        public int? Orders { get; set; }
        public string MetaKey { get; set; }
        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
        public int? LangID { get; set; }

        public virtual Status Status { get; set; }
        public virtual Languages Languages { get; set; }
        public virtual IList<ImageCarousel> ImageCarousels { get; set; }
    }
}
