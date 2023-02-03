using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TK_WebProject.Entities.Entities
{
    public class X_BlogCategory
    {
        [Key]
        public int ID { get; set; }

        public int BlogID { get; set; }
        public int BlogCategoryID { get; set; }

        public  Blog Blog { get; set; }
        public  BlogCategory BlogCategory { get; set; }
    }
}


