using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TK_WebProject.Entities.Entities
{
    public class ContactCategory
    {
        [Key]
        public int ID { get; set; }
        public string ContactCategoryName { get; set; }
        public int LangID { get; set; }

        public virtual IList<Contact> Contacts { get; set; }
    }
}
