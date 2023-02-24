using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class Event : BaseEntity
    {
        public string? Title { get; set; }
        public string? Description { get; set; }

        public DateTime? StartDatetime { get; set; }

        public DateTime? FinishDatetime { get; set; }

        
        public int? EventCategoryID { get; set; }

        public int? CreateUserID { get; set; }
        public int? StatusID { get; set; }
        public DateTime? CreateDate { get; set; }

        public virtual EventCategory EventCategory { get; set; }
    }
}
