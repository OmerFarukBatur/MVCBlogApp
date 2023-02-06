using MVCBlogApp.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace MVCBlogApp.Domain.Entities
{
    public class ConsultancyForm : BaseEntity
    {
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

        public virtual ConsultancyFormType ConsultancyFormType { get; set; }

    }
}
