using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.UserIslemleri.MemberAppointment.GetAllMemberAppointment
{
    public class GetAllMemberAppointmentQueryResponse
    {
        public List<VM_D_Appointment> D_Appointments { get; set; }
    }
}