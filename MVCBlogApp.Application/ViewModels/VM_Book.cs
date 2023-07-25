namespace MVCBlogApp.Application.ViewModels
{
    public class VM_Book
    {
        public int? Id { get; set; }
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

        public string? Language { get; set; }
        public string? NavigationName { get; set; }
        public string? StatusName { get; set; }
        public string? NavigationOrderNo { get; set; }

        public List<VM_Language>? Languages { get; set; }
        public List<AllStatus>? Statuses { get; set; }
        public List<VM_Navigation>? Navigations { get; set; }
        public VM_MasterRoot? MasterRoot { get; set; }
    }
}
