using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.ViewModels;
using MVCBlogApp.Domain.Entities;
using Newtonsoft.Json.Linq;

namespace MVCBlogApp.Infrastructure.Services
{
    public class OperationService : IOperationService
    {
        public SessionUser GetUser(JObject user)
        {
            
            string Role = user.GetValue("Role").ToString();
            string AuthRole = user.GetValue("AuthRole").ToString();
            string Email = user.GetValue("Email").ToString();
            string Id = user.GetValue("Id").ToString();

            return new SessionUser() 
            {
                AuthRole = AuthRole != null ? AuthRole : null,
                Email = Email,
                Id = int.Parse(Id),
                Role = bool.Parse(Role)
            };
        }
    }
}
