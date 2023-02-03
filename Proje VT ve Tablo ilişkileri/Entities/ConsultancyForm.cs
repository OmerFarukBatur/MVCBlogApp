using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TK_WebProject.Entities.Entities
{
    public class ConsultancyForm
    {
        [Key]
        public int ID { get; set; }


        [Display(Name ="Tip")]
        public int ConsultancyFormTypeID { get; set; }
        [Display(Name = "Adı Soyadı")]
        public string NameSurname { get; set; }
        [Display(Name = "Mail Adresi")]
        public string Email { get; set; }
        [Display(Name = "Telefon")]
        public string Phone { get; set; }
        [Display(Name = "Konu")]
        public string Subject { get; set; }
        [Display(Name = "Mesajınız")]
        public string Message { get; set; }
        [Display(Name = "Tip")]
        public int StatusID { get; set; }

        public DateTime CreateDate { get; set; }

        public virtual ConsultancyFormType ConsultancyFormType { get; set; }

    }
}
