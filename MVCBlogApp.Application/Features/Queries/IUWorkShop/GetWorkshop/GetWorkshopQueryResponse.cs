using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.IUWorkShop.GetWorkshop
{
    public class GetWorkshopQueryResponse
    {
        public List<VM_Workshop>? Workshops { get; set; }
    }
}