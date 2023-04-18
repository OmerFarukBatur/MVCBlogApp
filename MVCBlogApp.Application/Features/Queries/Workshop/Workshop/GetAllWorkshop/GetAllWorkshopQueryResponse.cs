using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.Workshop.Workshop.GetAllWorkshop
{
    public class GetAllWorkshopQueryResponse
    {
        public List<VM_Workshop> Workshops { get; set; }
    }
}