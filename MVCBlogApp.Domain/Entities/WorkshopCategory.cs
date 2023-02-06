using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class WorkshopCategory : BaseEntity
    {
        public string WSCategoryName { get; set; }
        public int LangID { get; set; }

        public virtual WorkshopEducation WorkshopEducation { get; set; }
    }
}
