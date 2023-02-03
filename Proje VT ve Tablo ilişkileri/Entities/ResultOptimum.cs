using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TK_WebProject.Entities.Entities
{
    public class ResultOptimum
    {
        [Key]
        public int ID { get; set; }
        public string Result1text { get; set; }
        public string Result2text { get; set; }
        public string Result3text { get; set; }
        public string Result4text { get; set; }
    }
}
