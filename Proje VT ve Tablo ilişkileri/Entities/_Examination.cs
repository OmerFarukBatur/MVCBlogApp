using System;
using System.Collections.Generic;
using System.Text;

namespace TK_WebProject.Entities.Entities
{
    public class _Examination
    {
        public int ID { get; set; }
        public int ExaminationID { get; set; }
        public int LabID { get; set; }

        public string Value { get; set; }

        public virtual Examination Examination { get; set; }
        public virtual Lab Lab { get; set; }
    }
}
