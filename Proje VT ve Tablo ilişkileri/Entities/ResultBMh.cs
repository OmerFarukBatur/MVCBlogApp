using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TK_WebProject.Entities.Entities
{
    public class ResultBMh
    {
        [Key]
        public int ID { get; set; }
        public string Resulttext { get; set; }
    }
}
