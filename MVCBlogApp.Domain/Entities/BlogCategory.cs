using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class BlogCategory : BaseEntity
    {
        public BlogCategory()
        {
            Blogs = new HashSet<Blog>();
        }

        public string? CategoryName { get; set; }
        public string? CategoryDescription { get; set; }
        public int? StatusId { get; set; }
        public int? LangId { get; set; }

        public virtual ICollection<Blog> Blogs { get; set; }
    }
}
