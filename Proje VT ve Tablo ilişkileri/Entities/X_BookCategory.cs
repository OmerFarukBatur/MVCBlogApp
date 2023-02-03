using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TK_WebProject.Entities.Entities
{
    public class X_BookCategory
    {
        [Key]
        public int ID { get; set; }
        public int BookID { get; set; }
        public int BookCategoryID { get; set; }
        public virtual Book Book { get; set; }
        public virtual BookCategory BookCategory { get; set; }
    }
}
