namespace MVCBlogApp.Application.ViewModels
{
    public class VM_Admin
    {
        public int? Id { get; set; }
        public string? Title { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public int? AuthId { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? CreateUserId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedUserId { get; set; }
        public string? AuthName { get; set; }
    }
}
