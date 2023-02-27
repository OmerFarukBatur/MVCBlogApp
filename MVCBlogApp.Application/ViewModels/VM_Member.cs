namespace MVCBlogApp.Application.ViewModels
{
    public class VM_Member
    {
        public int? Id { get; set; }
        public string? NameSurname { get; set; }
        public string? Email { get; set; }
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public string? Phone { get; set; }
        public string? Lacation { get; set; }
        public string? Address { get; set; }
        public int? MembersAuthId { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? CreateUserId { get; set; }
        public bool? IsActive { get; set; }
        public string? MemberAuthName { get; set; }
    }
}
