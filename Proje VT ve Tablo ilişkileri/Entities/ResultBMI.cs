using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TK_WebProject.Entities.Entities
{
    public class ResultBMI
    {
        [Key]
        public int ID { get; set; }
        public decimal IntervalMin { get; set; }
        public decimal IntervalMax { get; set; }
        public string IntervalDescription { get; set; }

    }
}
