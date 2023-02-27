using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class BlogType : BaseEntity
    {
        public BlogType()
        {
            Blogs = new HashSet<Blog>();
        }

        public string? TypeName { get; set; }
        public int? LangId { get; set; }

        public virtual ICollection<Blog> Blogs { get; set; }
    }
}
