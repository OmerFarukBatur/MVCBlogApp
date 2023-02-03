using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TK_WebProject.Entities.Entities
{
    public class D_Appointment
    {
        [Key]
        public int ID { get; set; }
        public int MembersID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public decimal Price { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }

        public int Interval { get; set; }
        public bool IsCompleted { get; set; }
        public int UserID { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateUserID { get; set; }
        public int StatusID { get; set; }

        public virtual IList<AppointmentDetail> AppointmentDetail { get; set; }
        public virtual Members Members { get; set; }
        public virtual User User { get; set; }
       

    }
}
