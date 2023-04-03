namespace MVCBlogApp.Application.ViewModels
{
    public class VM_FixBmh
    {
        public int? Id { get; set; }
        public int? FormId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? ImgUrl { get; set; }
        public int? StatusId { get; set; }
        public int? LangId { get; set; }

        public string? FormName { get; set; }
        public string? Language { get; set; }
        public string? StatusName { get; set; }
    }
}
