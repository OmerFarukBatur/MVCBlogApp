using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.UserIslemleri.ConsultancyForm.GetAllConsultancyForm
{
    public class GetAllConsultancyFormQueryResponse
    {
        public List<VM_ConsultancyForm> ConsultancyForms { get; set; }
    }
}