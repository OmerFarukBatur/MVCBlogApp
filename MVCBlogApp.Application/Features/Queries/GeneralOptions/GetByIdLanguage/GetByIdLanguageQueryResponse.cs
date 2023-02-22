using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.GeneralOptions.GetByIdLanguage
{
    public class GetByIdLanguageQueryResponse
    {
        public VM_Language? Language { get; set; }
        public bool State { get; set; }
    }
}