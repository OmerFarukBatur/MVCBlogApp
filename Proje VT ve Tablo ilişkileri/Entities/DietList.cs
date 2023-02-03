using System;
using System.Collections.Generic;
using System.Text;

namespace TK_WebProject.Entities.Entities
{
    public class DietList
    {

        public int ID { get; set; }

        public int AppointmentDetailID { get; set; }
        public int UserID { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate{ get; set; }

        public virtual AppointmentDetail AppointmentDetail { get; set; }
        public virtual User Users { get; set; }
        public virtual IList<_DaysMeal> _DaysMeal { get; set; }

    }
}
