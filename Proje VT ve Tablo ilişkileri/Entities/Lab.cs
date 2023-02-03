using System;
using System.Collections.Generic;
using System.Text;

namespace TK_WebProject.Entities.Entities
{
    public class Lab
    {
        public int ID { get; set; }

        public int AppointmentDetailID { get; set; }
        public int MembersID { get; set; }
        public int UsersID { get; set; }
        public DateTime LabDateTime { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }

      
        public virtual Members Members { get; set; }
        public virtual User User { get; set; }
        public virtual IList<_Examination> _Examination { get; set; }
    }
}
