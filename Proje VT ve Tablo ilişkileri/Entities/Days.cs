using System;
using System.Collections.Generic;
using System.Text;

namespace TK_WebProject.Entities.Entities
{
    public class Days
    {
        public int ID { get; set; }
        public string DayName { get; set; }

        public virtual IList<_DaysMeal> _DaysMeal { get; set; }

    }
}
