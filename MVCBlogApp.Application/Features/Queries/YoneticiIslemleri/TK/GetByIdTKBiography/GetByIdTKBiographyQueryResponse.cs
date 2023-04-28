using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.YoneticiIslemleri.TK.GetByIdTKBiography
{
    public class GetByIdTKBiographyQueryResponse
    {
        public string? Message { get; set; }
        public bool State { get; set; }
        public VM_TaylanK? TaylanK { get; set; }
        public List<VM_Language>? Languages { get; set; }
        public List<AllStatus>? Statuses { get; set; }
    }
}