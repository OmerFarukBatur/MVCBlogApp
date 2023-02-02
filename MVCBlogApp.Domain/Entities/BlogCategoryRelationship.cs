using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCBlogApp.Domain.Entities
{
    public class BlogCategoryRelationship
    {
        public string BlogID { get; set; }
        public string BlogCategoryID { get; set; } // İkisi composite key olacak

        public Blog Blog { get; set; }
        public BlogCategory BlogCategory { get; set; }
    }
}
