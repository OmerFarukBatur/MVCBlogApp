using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class MasterRoot : BaseEntity
    {
        public string Controller { get; set; }

        public string Action { get; set; }

        public string UrlRoot { get; set; }
    }
}
