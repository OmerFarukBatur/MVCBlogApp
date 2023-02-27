using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class MetaKeyword : BaseEntity
    {
        public string? Page { get; set; }
        public string? Title { get; set; }
        public string? MetaTitle { get; set; }
        public string? MetaKey { get; set; }
        public string? MetaDescription { get; set; }
        public string? Canonical { get; set; }
        public int? StatusId { get; set; }
        public int? LangId { get; set; }
    }
}
