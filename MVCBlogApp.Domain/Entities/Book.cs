using MVCBlogApp.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace MVCBlogApp.Domain.Entities
{
    public class Book : BaseEntity
    {
        
        public string BookName { get; set; }
        public int? PublicationYear { get; set; }
        public string UrlRoot { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public int? CreateUserID { get; set; }
        public int? StatusID { get; set; }
        public bool IsMainPage { get; set; }
        public int? Orders { get; set; }
        public int? NavigationID { get; set; }
        public int LangID { get; set; }

        public virtual Languages Languages { get; set; }
        public virtual IList<X_BookCategory> X_BookCategories { get; set; }
        public virtual Status Status { get; set; }
    }
}
