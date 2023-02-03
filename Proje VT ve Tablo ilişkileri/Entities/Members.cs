using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TK_WebProject.Entities.Entities
{
    public class Members
    {
        [Key]
        public int ID { get; set; }

        public string NameSurname { get; set; }
        public string EMail { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Phone { get; set; }
        public string Lacation { get; set; }
        public string Address { get; set; }

        public int MembersAuthID { get; set; }

        public DateTime? CreateDate { get; set; }

        public int? CreateUserID { get; set; }
        public bool IsActive { get; set; }

        //İlişkiler
        public virtual MembersAuth MembersAuth { get; set; }
        public virtual MembersDetail MembersDetail { get; set; }
        public virtual IList<D_Appointment> D_Appointment { get; set; }
        public virtual IList<AppointmentDetail> AppointmentDetail { get; set; }
        public virtual IList<Lab> Lab { get; set; }

    }
}
