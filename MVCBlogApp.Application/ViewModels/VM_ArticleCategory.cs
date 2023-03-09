namespace MVCBlogApp.Application.ViewModels
{
    public class VM_ArticleCategory
    {
        public int? Id { get; set; }
        public string? MetaTitle { get; set; }
        public string? MetaKey { get; set; }
        public string? MetaDescription { get; set; }
        public string? CategoryName { get; set; }
        public int? ParentId { get; set; }
        public int? CreateUserId { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? StatusId { get; set; }
        public int? LangId { get; set; }

        public string? StatusName { get; set; }
        public string? Language { get; set; }
        public string? ParentName { get; set; }
    }
}
