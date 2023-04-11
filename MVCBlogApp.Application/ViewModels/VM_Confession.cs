namespace MVCBlogApp.Application.ViewModels
{
    public class VM_Confession
    {
        public int? Id { get; set; }
        public string? MemberConfession { get; set; }
        public string? MemberName { get; set; }
        public bool? IsVisible { get; set; }
        public bool? IsAprove { get; set; }
        public bool? IsRead { get; set; }
        public DateTime? CreateDatetime { get; set; }
        public int? StatusId { get; set; }
        public int? LangId { get; set; }

        public string? Language { get; set; }
        public string? StatusName { get; set; }
    }
}
