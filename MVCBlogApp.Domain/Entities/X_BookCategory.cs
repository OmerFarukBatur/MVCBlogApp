using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class X_BookCategory : BaseEntity
    {
        public int? BookId { get; set; }
        public int? BookCategoryId { get; set; }

        public virtual Book? Book { get; set; }
        public virtual BookCategory? BookCategory { get; set; }
    }
}
