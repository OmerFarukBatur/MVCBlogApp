using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class Event : BaseEntity
    {
        public string? Title { get; set; }
        public string Description { get; set; } = null!;
        public DateTime? StartDatetime { get; set; }
        public DateTime? FinishDatetime { get; set; }
        public int? EventCategoryId { get; set; }
        public int? CreateUserId { get; set; }
        public int? StatusId { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
