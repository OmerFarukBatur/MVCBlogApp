using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TK_WebProject.Entities.Entities
{
    public class NewsBulletin
    {
        [Key]
        public int ID { get; set; }
        public string Email { get; set; }
        public int? CreateUserID { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? StatusID { get; set; }
        public virtual Status Status { get; set; }
    }
}
