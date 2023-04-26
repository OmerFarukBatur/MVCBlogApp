using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.GeneralOptions.Contact.GetAllContact
{
    public class GetAllContactQueryResponse
    {
        public List<VM_Contact> Contacts { get; set; }
    }
}