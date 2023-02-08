using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class WorkshopEducation : BaseEntity
    {
        public int WSCategoryID { get; set; }
        public string WsEducationName { get; set; }
        public int StatusID { get; set; }
        public int LangID { get; set; }

        public virtual Languages Languages { get; set; }
        public virtual IList<WorkshopCategory> WorkshopCategory { get; set; }
        public virtual IList<Workshop> Workshop { get; set; }
    }
}
