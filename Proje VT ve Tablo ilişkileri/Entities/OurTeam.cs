using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TK_WebProject.Entities.Entities
{
    public class OurTeam
    {
        [Key]
        public int ID { get; set; }
        public string NameSurname { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Bio { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? CreateUserID { get; set; }
        public int? StatusID { get; set; }
        public int? LangID { get; set; }
        public virtual Status Status { get; set; }
    }
}
