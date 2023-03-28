namespace MVCBlogApp.Application.ViewModels
{
    public class VM_SeminarVisuals
    {
        public int? Id { get; set; }
        public string? Title { get; set; }
        public string? ImgUrl { get; set; }
        public DateTime? Date { get; set; }
        public string? Location { get; set; }
        public string? Description { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? LangId { get; set; }
        public int? StatusId { get; set; }

        public string? Language { get; set; }
        public string? StatusName { get; set; }
    }
}
