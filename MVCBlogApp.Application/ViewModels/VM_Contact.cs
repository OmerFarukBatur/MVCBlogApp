namespace MVCBlogApp.Application.ViewModels
{
    public class VM_Contact
    {
        public int? Id { get; set; }
        public string? NameSurname { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Subject { get; set; }
        public string? Description { get; set; }
        public bool? IsRead { get; set; }
        public int? StatusId { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? ContactCategoryId { get; set; }

        public string? StatusName { get; set; }
        public string? ContactCategoryName { get; set; }
    }
}
