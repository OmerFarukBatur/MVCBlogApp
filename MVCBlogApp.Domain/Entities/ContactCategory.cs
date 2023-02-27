using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class ContactCategory : BaseEntity
    {
        public string? ContactCategoryName { get; set; }
        public int? LangId { get; set; }
    }
}
