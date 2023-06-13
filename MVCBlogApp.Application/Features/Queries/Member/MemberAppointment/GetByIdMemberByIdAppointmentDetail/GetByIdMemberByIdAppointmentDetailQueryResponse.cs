using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.Member.MemberAppointment.GetByIdMemberByIdAppointmentDetail
{
    public class GetByIdMemberByIdAppointmentDetailQueryResponse
    {
        public VM_D_Appointment? D_Appointment { get; set; }
        public string? Message { get; set; }
        public bool State { get; set; }
    }
}