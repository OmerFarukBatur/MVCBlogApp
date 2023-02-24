using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class X_BookCategory : BaseEntity
    {
        public int? BookID { get; set; }
        public int? BookCategoryID { get; set; }
        public virtual Book Book { get; set; }
        public virtual BookCategory BookCategory { get; set; }
    }
}
