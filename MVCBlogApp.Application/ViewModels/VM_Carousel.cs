namespace MVCBlogApp.Application.ViewModels
{
    public class VM_Carousel
    {
        public int? Id { get; set; }
        public string? Title { get; set; }
        public string? Controller { get; set; }
        public string? Action { get; set; }
        public string? UrlRoot { get; set; }
        public string? TitleClass { get; set; }
        public string? ImgName { get; set; }
        public string? ImgUrl { get; set; }
        public string? Description { get; set; }
        public int? CreateUserId { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? Orders { get; set; }
        public int? StatusId { get; set; }
        public string? MetaKey { get; set; }
        public string? MetaTitle { get; set; }
        public string? MetaDescription { get; set; }
        public int? LangId { get; set; }

        public string? Language { get; set; }
        public string? StatusName { get; set; }
    }
}
