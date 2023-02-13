using MediatR;

namespace MVCBlogApp.Application.Features.Queries.Home.Login
{
    public class LoginQueryRequest : IRequest<LoginQueryResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}