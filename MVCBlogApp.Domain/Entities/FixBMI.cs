using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class FixBMI : BaseEntity
    {
        public int FormID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public int StatusID { get; set; }
        public int LangID { get; set; }
        public virtual Form Form { get; set; }
    }
}
