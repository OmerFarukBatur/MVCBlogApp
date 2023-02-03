using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TK_WebProject.Entities.Entities
{
    public class CalcBMI
    {
        [Key]
        public int ID { get; set; }
        public int Size { get; set; }
        public int Weight { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public decimal Result { get; set; }
    }
}
