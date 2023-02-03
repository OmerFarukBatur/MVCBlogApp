using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TK_WebProject.Entities.Entities
{
    public class BlogType
    {
        [Key]
        public int ID { get; set; }
        public string TypeName { get; set; }
        public virtual IList<Blog> Blogs { get; set; }
    }
}
