using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.YoneticiIslemleri.TK.GetTKBiographyCreateItems
{
    public class GetTKBiographyCreateItemsQueryResponse
    {
        public List<VM_Language> Languages { get; set; }
        public List<AllStatus> Statuses { get; set; }
    }
}