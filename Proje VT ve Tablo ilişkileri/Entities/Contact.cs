using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace TK_WebProject.Entities.Entities
{
    public class Contact
    {
        [Key]
        public int ID { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public bool? IsRead { get; set; }
        public int? StatusID { get; set; }
        public DateTime? CreateDate { get; set; }
        public virtual Status Status { get; set; }
        public int? ContactCategoryID { get; set; }

        public virtual ContactCategory ContactCategory { get; set; }
    }
}
