namespace MVCBlogApp.Application.Features.Queries.Home.Login
{
    public class LoginQueryResponse
    {
        public string? AuthRole { get; set; }
        public bool Role { get; set; } = false;
        public string? Email { get; set; }
        public int? Id { get; set; }
        public string? Message { get; set; }
    }
}