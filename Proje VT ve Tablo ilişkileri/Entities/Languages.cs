using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TK_WebProject.Entities.Entities
{
    public class Languages
    {
        [Key]
        public int ID { get; set; }

        public string Language { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool IsActive { get; set; }

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
