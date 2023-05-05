namespace MVCBlogApp.Application.ViewModels
{
    public class VM_CalenderData
    {
        public int? Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public bool? AllDay { get; set; }
        public string? Color { get; set; }
    }
}
