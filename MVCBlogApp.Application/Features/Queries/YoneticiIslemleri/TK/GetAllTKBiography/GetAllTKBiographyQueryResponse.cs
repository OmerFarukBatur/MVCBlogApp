using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.YoneticiIslemleri.TK.GetAllTKBiography
{
    public class GetAllTKBiographyQueryResponse
    {
        public List<VM_TaylanK> TaylanKs { get; set; }
    }
}