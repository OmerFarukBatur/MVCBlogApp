using Microsoft.AspNetCore.Http;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.ViewModels;
using Newtonsoft.Json.Linq;
using System.Data;

namespace MVCBlogApp.Infrastructure.Services
{
    public class OperationService : IOperationService
    {
        private readonly IHttpContextAccessor _accessor;

        public OperationService(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public SessionUser GetUser()
        {
            var checkUser = _accessor.HttpContext.Session.GetString("users");

            if (checkUser != null)
            {
                JObject user = JObject.Parse(checkUser);
                string Role = user.GetValue("Role").ToString();
                string AuthRole = user.GetValue("AuthRole").ToString();
                string Email = user.GetValue("Email").ToString();
                string Id = user.GetValue("Id").ToString();

                return new SessionUser()
                {
                    AuthRole = AuthRole != null ? AuthRole : "Danışan",
                    Email = Email,
                    Id = int.Parse(Id),
                    Role = bool.Parse(Role)
                };
            }
            else
            {
                return new SessionUser()
                {
                    AuthRole = null,
                    Email = null,
                    Id = 0,
                    Role = false
                };
            }
        }

        public string? MakeShorter(string? value, int valueLength)
        {
            if (value != null)
            {
                if (value.Length <= valueLength)
                {
                    return value;
                }
                else
                {
                    string newValue = value.Substring(0, valueLength);
                    newValue += "...";
                    return newValue;
                }
            }
            else
            {
                return null;
            }
        }

        public int SessionLangId()
        {
            int id = Convert.ToInt32(_accessor.HttpContext.Session.GetInt32("LangID"));
            if (id == 0 ) { id = 1; }

            return id;
        }
    }
}
