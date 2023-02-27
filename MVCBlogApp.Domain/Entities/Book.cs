using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class Book : BaseEntity
    {
        public Book()
        {
            X_BookCategory = new HashSet<X_BookCategory>();
        }

        public string? MetaTitle { get; set; }
        public string? MetaKey { get; set; }
        public string? MetaDescription { get; set; }
        public string? BookName { get; set; }
        public int? PublicationYear { get; set; }
        public string? UrlRoot { get; set; }
        public string? Content { get; set; }
        public string? ImageUrl { get; set; }
        public string? Controller { get; set; }
        public string? Action { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? CreateUserId { get; set; }
        public int? StatusId { get; set; }
        public bool? IsMainPage { get; set; }
        public int? Orders { get; set; }
        public int? NavigationId { get; set; }
        public int? LangId { get; set; }

        public virtual ICollection<X_BookCategory> X_BookCategory { get; set; }
    }
}
