using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class ArticleCategory : BaseEntity
    {
        public string MetaTitle { get; set; }
        public string MetaKey { get; set; }
        public string MetaDescription { get; set; }
        public string CategoryName { get; set; }
        public int? ParentID { get; set; }
        public int? CreateUserID { get; set; }
        public int? StatusID { get; set; }
        public int? LangID { get; set; }

        public virtual Status Status { get; set; }
        public virtual IList<Article> Article { get; set; }
    }
}
