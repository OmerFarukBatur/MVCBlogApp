using MVCBlogApp.Application.ViewModels;
using Newtonsoft.Json.Linq;

namespace MVCBlogApp.Application.Abstractions.Services
{
    public interface IOperationService
    {
        SessionUser GetUser();
        int SessionLangId();
    }
}
