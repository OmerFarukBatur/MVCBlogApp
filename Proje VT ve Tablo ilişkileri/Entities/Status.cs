using System;
using System.Collections.Generic;
using System.Text;

namespace TK_WebProject.Entities.Entities
{
    public class Status
    {
        public int ID { get; set; }
        public string StatusName { get; set; }

        public virtual IList<TaylanK> TaylanK { get; set; }
        

    }
}
