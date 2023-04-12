using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.UserIslemleri.ConsultancyFormType.GetAllCFT
{
    public class GetAllCFTQueryResponse
    {
        public List<VM_ConsultancyFormType> ConsultancyFormTypes { get; set; }
    }
}