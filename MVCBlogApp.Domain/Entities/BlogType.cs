using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class BlogType : BaseEntity
    {
        public string? TypeName { get; set; }
        public virtual IList<Blog> Blogs { get; set; }
    }
}
