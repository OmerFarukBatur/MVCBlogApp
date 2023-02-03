using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCBlogApp.Domain.Entities
{
    public class BlogCategoryRelationship
    {
        public Guid BlogID { get; set; }
        public Guid BlogCategoryID { get; set; } // İkisi composite key olarak ayarlandı.

        public Blog Blog { get; set; }
        public BlogCategory BlogCategory { get; set; }
    }
}
