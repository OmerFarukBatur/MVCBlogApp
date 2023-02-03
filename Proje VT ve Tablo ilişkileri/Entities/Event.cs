using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TK_WebProject.Entities.Entities
{
    public class Event
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Bu alan boş geçilemez")]
        public string Title { get; set; }
        public string Description { get; set; }

        [Required(ErrorMessage = "Bu alan boş geçilemez")]
        [Remote(action: "ValidateDates", controller: "Calendar", areaName: "Yonetim", AdditionalFields = nameof(StartDatetime), ErrorMessage = "Bu Tarih Aralığı Uygun Değil")]
        public DateTime StartDatetime { get; set; }

        [Required(ErrorMessage = "Bu alan boş geçilemez")]
        [Remote(action: "ValidateDates", controller: "Calendar", areaName:"Yonetim", AdditionalFields = nameof(StartDatetime), ErrorMessage = "Bu Tarih Aralığı Uygun Değil")]
        public DateTime FinishDatetime { get; set; }

        [Required(ErrorMessage = "Bu alan boş geçilemez")]
        public int? EventCategoryID { get; set; }

        public int CreateUserID { get; set; }
        public int StatusID { get; set; }
        public DateTime? CreateDate { get; set; }

        public virtual EventCategory EventCategory { get; set; }

    }
}
