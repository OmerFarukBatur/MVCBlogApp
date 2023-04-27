using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.GeneralOptions.ContactCategory.GetByIdContactCategory
{
    public class GetByIdContactCategoryQueryResponse
    {
        public string? Message { get; set; }
        public bool State { get; set; }
        public List<VM_Language>? Languages { get; set; }
        public VM_ContactCategory? ContactCategory { get; set; }
    }
}