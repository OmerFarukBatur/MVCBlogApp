using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.Member.Contact.GetMemberContactCreateItems
{
    public class GetMemberContactCreateItemsQueryResponse
    {
        public VM_Member Member { get; set; }
        public List<VM_ContactCategory> ContactCategories { get; set; }
        public List<AllStatus> Statuses { get; set; }
    }
}