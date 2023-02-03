using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TK_WebProject.Entities.Entities
{
    public class BlogCategory
    {
        [Key]
        public int ID { get; set; }

        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public int StatusID { get; set; }
        public int LangID { get; set; }

       
        public virtual Status Status { get; set; }
        public virtual IList<X_BlogCategory> X_BlogCategory { get; set; }
    }
}
