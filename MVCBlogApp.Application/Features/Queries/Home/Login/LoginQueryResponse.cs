namespace MVCBlogApp.Application.Features.Queries.Home.Login
{
    public class LoginQueryResponse
    {
        public string? Role { get; set; }
        public string? Email { get; set; }
        public int? Id { get; set; }
        public string? Message { get; set; }
    }
}