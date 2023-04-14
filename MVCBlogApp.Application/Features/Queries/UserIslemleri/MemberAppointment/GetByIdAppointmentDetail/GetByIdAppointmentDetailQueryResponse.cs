using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.UserIslemleri.MemberAppointment.GetByIdAppointmentDetail
{
    public class GetByIdAppointmentDetailQueryResponse
    {
        public string? Message { get; set; }
        public bool State { get; set; }
        public VM_AppointmentDetail? AppointmentDetail { get; set; }
    }
}