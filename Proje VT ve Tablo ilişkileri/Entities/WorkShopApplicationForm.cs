using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TK_WebProject.Entities.Entities
{
    public class WorkShopApplicationForm
    {
        [Key]
        public int ID { get; set; }

        public int WorkShopID { get; set; }

        [Display(Name ="Adı Soyadı")]
        public string NameSurname { get; set; }
        [Display(Name = "Mail Adresi")]
        public string Email { get; set; }
        [Display(Name = "Telefon Numarası")]
        public string Phone { get; set; }
        [Display(Name = "Doğum Tarihi")]
        public DateTime BirthDate { get; set; }
        [Display(Name = "Cinsiyet")]
        public int Gender { get; set; }
        [Display(Name = "Meslek")]
        public string Job { get; set; }
        [Display(Name = "Adres")]
        public string Address { get; set; }

        //FK
        public int HearAboutusID { get; set; }

        [Display(Name = "Katılım Amacı")]
        public string AttendancePurpose { get; set; }

        [Display(Name = "Yaşam Tarzınızdan Memnun Musunuz ?")]
        public int LifeContented { get; set; }

        [Display(Name = "Kilo vermek / almak için daha önce hiç diyet yaptınız mı?")]
        public int Diet { get; set; }

        [Display(Name = "Mesaj")]
        public string Note { get; set; }

        [Display(Name = "Onay Verildi mi?")]
        public bool IsApprove { get; set; }
        public DateTime CreateDateTime { get; set; }

        public virtual HearAboutUS HearAboutUS { get; set; }
        public virtual Workshop Workshop { get; set; }

       



    }
}
