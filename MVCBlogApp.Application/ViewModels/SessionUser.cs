namespace MVCBlogApp.Application.ViewModels
{
    public class SessionUser
    {
        public string? AuthRole { get; set; }
        public bool Role { get; set; } = false;
        public string? Email { get; set; }
        public int Id { get; set; }
    }
}
