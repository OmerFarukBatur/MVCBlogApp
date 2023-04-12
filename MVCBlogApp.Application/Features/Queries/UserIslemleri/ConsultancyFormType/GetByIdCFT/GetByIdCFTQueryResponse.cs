using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.UserIslemleri.ConsultancyFormType.GetByIdCFT
{
    public class GetByIdCFTQueryResponse
    {
        public VM_ConsultancyFormType? ConsultancyFormType { get; set; }
        public string? Message { get; set; }
        public bool State { get; set; }
    }
}