using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TK_WebProject.Entities.Entities
{
    public class ResultPulse
    {
        [Key]
        public int ID { get; set; }
        public string ResultMaxText { get; set; }
        public string ResultMinText { get; set; }
    }
}
