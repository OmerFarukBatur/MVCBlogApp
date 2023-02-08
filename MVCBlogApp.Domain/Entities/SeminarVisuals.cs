using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class SeminarVisuals : BaseEntity
    {
        public string Title { get; set; }
        public string ImgUrl { get; set; }

        public DateTime Date { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }

        public int LangID { get; set; }
        public int StatusID { get; set; }

        public virtual Languages Languages { get; set; }
        public virtual Status Status { get; set; }
    }
}
