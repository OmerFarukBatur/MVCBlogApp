using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class AppointmentDetail : BaseEntity
    {
        public int AppointmentID { get; set; }

        public string Diagnosis { get; set; }
        public string History { get; set; }
        public string Treatment { get; set; }
        public int MembersID { get; set; }
        public int UserID { get; set; }

        public decimal Weight { get; set; }
        public decimal Size { get; set; }
        public decimal OilRate { get; set; }

        public virtual D_Appointment D_Appointment { get; set; }
        public virtual Members Members { get; set; }
        public virtual User User { get; set; }
        public virtual IList<DietList> DietList { get; set; }

    }
}
