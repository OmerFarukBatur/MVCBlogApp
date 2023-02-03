using System;
using System.Collections.Generic;
using System.Text;

namespace TK_WebProject.Entities.Entities
{
    public class Banner
    {
        public int ID { get; set; }

        public string BannerName { get; set; }
        public string BannerUrl { get; set; }

        public int Type { get; set; }
        public int BannerOrder { get; set; }
        public int StatusID { get; set; }
        public string DateString { get; set; }

        public int LangID { get; set; }

        public virtual Languages Languages { get; set; }
    }
}
