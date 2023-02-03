using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TK_WebProject.Entities.Entities
{
    public class SeminarVisuals
    {
        [Key]
        public int ID { get; set; }

        public string Title { get; set; }
        public string ImgUrl { get; set; }
        
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }

        public int LangID { get; set; }
        public int StatusID { get; set; }

        public virtual Languages Languages { get; set; }
        public virtual Status Status { get; set; }

    }
}
