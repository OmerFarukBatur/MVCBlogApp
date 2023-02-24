using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class SLeftNavigation : BaseEntity
    {
        public string? Title { get; set; }
        public string? Url { get; set; }
        public int? Type { get; set; }
        public int? LangID { get; set; }
    }
}
