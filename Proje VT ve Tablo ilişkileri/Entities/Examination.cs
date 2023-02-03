using System;
using System.Collections.Generic;
using System.Text;

namespace TK_WebProject.Entities.Entities
{
    public class Examination
    {
        public int ID { get; set; }
        public string ExaminationName { get; set; }

        public virtual IList<_Examination> _Examination { get; set; }
    }
}
