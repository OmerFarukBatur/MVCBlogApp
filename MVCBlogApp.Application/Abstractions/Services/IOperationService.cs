using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Abstractions.Services
{
    public interface IOperationService
    {
        SessionUser GetUser();
        int SessionLangId();
        string? MakeShorter(string? value, int valueLength);
    }
}
