using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class Press : BaseEntity
    {
        public string? urlRoot { get; set; }
        public int? NewsPaperID { get; set; }
        public string? Title { get; set; }
        public string? SubTitle { get; set; }
        public string? Description { get; set; }
        public string? UrlLink { get; set; }
        public string? MetaTitle { get; set; }
        public string? MetaKey { get; set; }
        public string? MetaDescription { get; set; }


        public int? StatusID { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? LangID { get; set; }
        public string? ImageUrl { get; set; }

        public int PressTypeID { get; set; }
        public virtual Languages Languages { get; set; }
        public virtual Status Status { get; set; }
        public virtual PressType PressType { get; set; }
        public virtual NewsPaper NewsPaper { get; set; }
    }
}
