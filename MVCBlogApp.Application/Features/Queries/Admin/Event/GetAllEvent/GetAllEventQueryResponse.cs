using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.Admin.Event.GetAllEvent
{
    public class GetAllEventQueryResponse
    {
        public List<VM_Event> Events { get; set; }
    }
}