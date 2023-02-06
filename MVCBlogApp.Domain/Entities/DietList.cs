using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class DietList : BaseEntity
    {
        public int AppointmentDetailID { get; set; }
        public int UserID { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public virtual AppointmentDetail AppointmentDetail { get; set; }
        public virtual User Users { get; set; }
        public virtual IList<_DaysMeal> _DaysMeal { get; set; }

    }
}
