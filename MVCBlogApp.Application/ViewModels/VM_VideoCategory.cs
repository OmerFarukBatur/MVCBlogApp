namespace MVCBlogApp.Application.ViewModels
{
    public class VM_VideoCategory
    {
        public int? Id { get; set; }
        public string? VideoCategoryName { get; set; }
        public int? StatusId { get; set; }
        public int? LangId { get; set; }

        public string? StatusNme { get; set; }
        public string? Language { get; set; }
    }
}
