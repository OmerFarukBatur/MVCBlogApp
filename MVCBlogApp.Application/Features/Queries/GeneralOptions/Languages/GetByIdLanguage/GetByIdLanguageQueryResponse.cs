using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.GeneralOptions.Languages.GetByIdLanguage
{
    public class GetByIdLanguageQueryResponse
    {
        public VM_Language? Language { get; set; }
        public bool State { get; set; }
    }
}