using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class WorkshopType : BaseEntity
    {
        public string? WstypeName { get; set; }
        public int? LangId { get; set; }
    }
}
