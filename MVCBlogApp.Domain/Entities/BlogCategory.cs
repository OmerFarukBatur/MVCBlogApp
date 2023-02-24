using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class BlogCategory : BaseEntity
    {
        public string? CategoryName { get; set; }
        public string? CategoryDescription { get; set; }
        public int? StatusID { get; set; }
        public int? LangID { get; set; }


        public virtual Status Status { get; set; }
        public virtual IList<X_BlogCategory> X_BlogCategory { get; set; }
    }
}
