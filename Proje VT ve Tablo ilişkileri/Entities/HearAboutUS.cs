using System;
using System.Collections.Generic;
using System.Text;

namespace TK_WebProject.Entities.Entities
{
    public class HearAboutUS
    {
        public int ID { get; set; }
        public string HearAboutUSName { get; set; }
        public int LangID { get; set; }

        public virtual IList<WorkShopApplicationForm> WorkShopApplicationForm { get; set; }
    }

    
}
