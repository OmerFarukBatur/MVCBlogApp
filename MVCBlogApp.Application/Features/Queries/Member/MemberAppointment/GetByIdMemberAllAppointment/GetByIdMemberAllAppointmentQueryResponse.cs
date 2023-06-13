using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.Member.MemberAppointment.GetByIdMemberAllAppointment
{
    public class GetByIdMemberAllAppointmentQueryResponse
    {
        public List<VM_D_Appointment> D_Appointments { get; set; }
    }
}