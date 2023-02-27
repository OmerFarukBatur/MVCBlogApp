using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class Article : BaseEntity
    {
        public string? MetaTitle { get; set; }
        public string? MetaKey { get; set; }
        public string? MetaDescription { get; set; }
        public int? ArticleCategoryId { get; set; }
        public string? UrlRoot { get; set; }
        public string? Controller { get; set; }
        public string? Action { get; set; }
        public string? Title { get; set; }
        public string? SubTitle { get; set; }
        public string? Description { get; set; }
        public int? AuthorUserId { get; set; }
        public int? Orders { get; set; }
        public string? CoverImgUrl { get; set; }
        public DateTime? ArticleDate { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? CreateUserId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateUserId { get; set; }
        public int? NavigationId { get; set; }
        public int? StatusId { get; set; }
        public int? LangId { get; set; }
        public bool? IsMainPage { get; set; }
        public bool? IsMenu { get; set; }
        public bool? IsComponent { get; set; }
        public bool? IsNewsComponent { get; set; }
        public string? FontAwesomeIcon { get; set; }

        public virtual ArticleCategory? ArticleCategory { get; set; }
    }
}
