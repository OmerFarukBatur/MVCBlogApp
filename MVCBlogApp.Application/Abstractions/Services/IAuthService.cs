using MVCBlogApp.Application.Features.Commands.Home.CreateUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCBlogApp.Application.Abstractions.Services
{
    public interface IAuthService
    {
        Task<CreateUserCommandResponse> CreateUserAsync(CreateUserCommandRequest request);
        (byte[] passwordSalt, byte[] passwordHash) CreatePasswordHash(string password);
    }
}
