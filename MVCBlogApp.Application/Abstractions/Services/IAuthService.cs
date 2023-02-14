using MVCBlogApp.Application.Features.Commands.Home.CreateUser;
using MVCBlogApp.Application.Features.Queries.Home.Login;

namespace MVCBlogApp.Application.Abstractions.Services
{
    public interface IAuthService
    {
        (byte[] passwordSalt, byte[] passwordHash) CreatePasswordHash(string password);
        bool VerifyPasswordHash(string Password, byte[] userpasswordHash, byte[] userpasswordSalt);
        Task<CreateUserCommandResponse> CreateUserAsync(CreateUserCommandRequest request);
        Task<LoginQueryResponse> Login(LoginQueryRequest request);
    }
}
