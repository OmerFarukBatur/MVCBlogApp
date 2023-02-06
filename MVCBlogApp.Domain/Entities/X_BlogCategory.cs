using System.ComponentModel.DataAnnotations;

namespace MVCBlogApp.Domain.Entities
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


