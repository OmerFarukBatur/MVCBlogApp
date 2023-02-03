using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TK_WebProject.Entities.Entities
{
    public class SLeftNavigation
    {
        [Key]
        public int ID { get; set; }

        public string Title { get; set; }
        public string Url { get; set; }
        public int Type { get; set; }
        public int LangID { get; set; }
       

    }
}
