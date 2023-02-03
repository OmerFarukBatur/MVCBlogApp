using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TK_WebProject.Entities.Entities
{
    public class CalcOptimum
    {
        [Key]
        public int ID { get; set; }
        public string Gender { get; set; }
        public int Size { get; set; }
        public int Weight { get; set; }
        public string Email { get; set; }
        public string NameSurname { get; set; }
        public int Age { get; set; }
        public decimal Result1 { get; set; }
        public decimal Result2 { get; set; }
        public decimal Result3 { get; set; }
        public decimal Result4 { get; set; }
    }
}
