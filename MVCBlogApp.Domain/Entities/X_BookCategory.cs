using System.ComponentModel.DataAnnotations;

namespace MVCBlogApp.Domain.Entities
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
