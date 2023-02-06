using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class Lab : BaseEntity
    {
        public int AppointmentDetailID { get; set; }
        public int MembersID { get; set; }
        public int UsersID { get; set; }
        public DateTime LabDateTime { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

      
        public virtual Members Members { get; set; }
        public virtual User User { get; set; }
        public virtual IList<_Examination> _Examination { get; set; }
    }
}
