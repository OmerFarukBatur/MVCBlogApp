using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class Auth : BaseEntity
    {
        public string? AuthName { get; set; }
    }
}
