using System;
using System.Collections.Generic;
using System.Text;

namespace TK_WebProject.Entities.Entities
{
    public class PressType
    {
        public int ID { get; set; }

        public string PressTypeName { get; set; }

        public virtual IList<Press> Press { get; set; }
    }
}
