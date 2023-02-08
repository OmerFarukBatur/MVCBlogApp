using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class BookCategory : BaseEntity
    {
        public string CategoryName { get; set; }
        public int? CreateUserID { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? StatusID { get; set; }
        public virtual IList<X_BookCategory> X_BookCategories { get; set; }
        public virtual Status Status { get; set; }
    }
}
