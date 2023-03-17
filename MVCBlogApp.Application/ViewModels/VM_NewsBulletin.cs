namespace MVCBlogApp.Application.ViewModels
{
    public class VM_NewsBulletin
    {
        public int? Id { get; set; }
        public string? Email { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? CreateUserId { get; set; }
        public int? StatusId { get; set; }

        public string? StatusName { get; set; }
    }
}
