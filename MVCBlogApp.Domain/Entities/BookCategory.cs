using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class BookCategory : BaseEntity
    {
        public BookCategory()
        {
            X_BookCategory = new HashSet<X_BookCategory>();
        }

        public string? CategoryName { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? CreateUserId { get; set; }
        public int? StatusId { get; set; }
        public int? LangId { get; set; }

        public virtual ICollection<X_BookCategory> X_BookCategory { get; set; }
    }
}
