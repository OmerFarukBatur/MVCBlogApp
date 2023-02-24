using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class X_BlogCategory : BaseEntity
    {
        public int? BlogID { get; set; }
        public int? BlogCategoryID { get; set; }

        public Blog Blog { get; set; }
        public BlogCategory BlogCategory { get; set; }
    }
}


