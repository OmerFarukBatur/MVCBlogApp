using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class ArticleCategory : BaseEntity
    {
        public ArticleCategory()
        {
            Articles = new HashSet<Article>();
        }

        public string? MetaTitle { get; set; }
        public string? MetaKey { get; set; }
        public string? MetaDescription { get; set; }
        public string? CategoryName { get; set; }
        public int? ParentId { get; set; }
        public int? CreateUserId { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? StatusId { get; set; }
        public int? LangId { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}
