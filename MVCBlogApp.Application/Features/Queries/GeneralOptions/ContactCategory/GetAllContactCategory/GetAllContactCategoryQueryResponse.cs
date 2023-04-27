using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.GeneralOptions.ContactCategory.GetAllContactCategory
{
    public class GetAllContactCategoryQueryResponse
    {
        public List<VM_ContactCategory> ContactCategories { get; set; }
    }
}