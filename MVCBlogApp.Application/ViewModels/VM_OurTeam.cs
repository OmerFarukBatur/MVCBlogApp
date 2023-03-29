namespace MVCBlogApp.Application.ViewModels
{
    public class VM_OurTeam
    {
        public int? Id { get; set; }
        public string? NameSurname { get; set; }
        public string? Title { get; set; }
        public string? ImageUrl { get; set; }
        public string? Bio { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? CreateUserId { get; set; }
        public int? StatusId { get; set; }
        public int? LangId { get; set; }

        public string? Language { get; set; }
        public string? StatusName { get; set; }
    }
}
