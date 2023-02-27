using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class Press : BaseEntity
    {
        public string? UrlRoot { get; set; }
        public int? NewsPaperId { get; set; }
        public string? Title { get; set; }
        public string? SubTitle { get; set; }
        public string? Description { get; set; }
        public string? UrlLink { get; set; }
        public string? MetaTitle { get; set; }
        public string? MetaKey { get; set; }
        public string? MetaDescription { get; set; }
        public int? StatusId { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? LangId { get; set; }
        public string? ImageUrl { get; set; }
        public int? PressTypeId { get; set; }
    }
}
