using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.Doctor.AppointmentDetail.GetByIdAppointmentDetail
{
    public class GetByIdAppointmentDetailQueryResponse
    {
        public List<VM_D_Appointment>? D_Appointments { get; set; }
        public List<VM_Member>? Members { get; set; }
        public List<VM_Admin>? Admins { get; set; }
        public VM_AppointmentDetail? AppointmentDetail { get; set; }
        public string? Message { get; set; }
        public bool State { get; set; }
    }
}