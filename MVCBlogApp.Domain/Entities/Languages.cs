using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class Languages : BaseEntity
    {
        public string Language { get; set; }

        public virtual IList<Navigation> Navigation { get; set; }
        public virtual IList<TaylanK> TaylanK { get; set; }
        public virtual IList<Article> Article { get; set; }
        public virtual IList<Blog> Blogs { get; set; }
        public virtual IList<Book> Books { get; set; }
        public virtual IList<Press> Presses { get; set; }
        public virtual IList<SeminarVisuals> SeminarVisuals { get; set; }
        public virtual IList<Workshop> Workshops { get; set; }
        public virtual IList<WorkshopEducation> WorkshopEducations { get; set; }
        public virtual IList<Banner> Banner { get; set; }
        public virtual IList<Carousel> Carousel { get; set; }
        public virtual IList<Video> Video { get; set; }

    }
}
