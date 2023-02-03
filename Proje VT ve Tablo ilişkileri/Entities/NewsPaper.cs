using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TK_WebProject.Entities.Entities
{
    public class NewsPaper
    {
        [Key]
        public int ID { get; set; }
        public string NewsPaperName { get; set; }
        public int? StatusID { get; set; }
        public int? LangID { get; set; }
        public virtual Status Status { get; set; }
        public virtual IList<Press> Press { get; set; }
    }
}
