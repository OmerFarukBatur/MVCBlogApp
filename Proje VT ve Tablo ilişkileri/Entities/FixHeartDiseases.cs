using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TK_WebProject.Entities.Entities
{
    public class FixHeartDiseases
    {
        [Key]
        public int ID { get; set; }
        public int FormID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public int StatusID { get; set; }
        public int LangID { get; set; }
        public virtual Form Form { get; set; }
    }
}
