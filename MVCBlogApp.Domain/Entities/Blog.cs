using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public  class Blog : BaseEntity
    {
        public string? MetaTitle { get; set; }
        public string? MetaKey { get; set; }
        public string? MetaDescription { get; set; }
        public string? UrlRoot { get; set; }
        public string? Title { get; set; }
        public string? SubTitle { get; set; }
        public string? Contents { get; set; }
        public string? Controller { get; set; }
        public string? Action { get; set; }
        public int? CreateUserID { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? UpdateUserID { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? LangID { get; set; }
        public int? StatusID { get; set; }
        public int? BlogCategoryID { get; set; }
        public string? CoverImgUrl { get; set; }
        public int? BlogTypeID { get; set; }
        public bool? IsMainPage { get; set; }
        public int? Orders { get; set; }
        public int? NavigationID { get; set; }
        public bool? IsMenu { get; set; }
        public bool? IsComponent { get; set; }
        public bool? IsNewsComponent { get; set; }

        public virtual Status Status { get; set; }

        public virtual Languages Languages { get; set; }
        public virtual IList<X_BlogCategory> X_BlogCategory { get; set; }
        public virtual IList<ImageBlog> ImageBlog { get; set; }
        public virtual User User { get; set; }
        public virtual BlogType BlogType { get; set; }
    }
}
