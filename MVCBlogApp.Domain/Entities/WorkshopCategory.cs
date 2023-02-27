using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class WorkshopCategory : BaseEntity
    {
        public string? WscategoryName { get; set; }
        public int? LangId { get; set; }
    }
}
