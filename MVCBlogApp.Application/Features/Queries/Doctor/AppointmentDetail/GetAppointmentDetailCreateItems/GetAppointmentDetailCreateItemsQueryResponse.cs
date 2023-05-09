using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.Doctor.AppointmentDetail.GetAppointmentDetailCreateItems
{
    public class GetAppointmentDetailCreateItemsQueryResponse
    {
        public List<VM_D_Appointment> D_Appointments { get; set; }
        public List<VM_Member> Members { get; set; }
        public List<VM_Admin> Admins { get; set; }
    }
}