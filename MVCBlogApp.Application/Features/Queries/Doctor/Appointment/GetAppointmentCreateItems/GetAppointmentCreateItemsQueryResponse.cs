using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.Doctor.Appointment.GetAppointmentCreateItems
{
    public class GetAppointmentCreateItemsQueryResponse
    {
        public List<VM_Member> Members { get; set; }
        public List<VM_Admin> Admins { get; set; }
        public List<AllStatus> Statuses { get; set; }
    }
}