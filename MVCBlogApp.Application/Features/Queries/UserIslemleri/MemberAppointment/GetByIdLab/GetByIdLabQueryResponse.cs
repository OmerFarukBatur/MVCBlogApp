using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.UserIslemleri.MemberAppointment.GetByIdLab
{
    public class GetByIdLabQueryResponse
    {
        public string? Message { get; set; }
        public bool State { get; set; }
        public List<VM_Examination>? Examinations { get; set; }
        public VM_Lab? Lab { get; set; }
    }
}