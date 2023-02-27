using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class X_BlogCategory : BaseEntity
    {
        public int? BlogId { get; set; }
        public int? BlogCategoryId { get; set; }
    }
}
