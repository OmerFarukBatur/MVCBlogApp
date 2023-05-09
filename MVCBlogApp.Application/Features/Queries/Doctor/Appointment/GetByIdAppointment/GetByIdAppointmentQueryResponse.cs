using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.Doctor.Appointment.GetByIdAppointment
{
    public class GetByIdAppointmentQueryResponse
    {
        public VM_D_Appointment? D_Appointment { get; set; }
        public List<VM_Member>? Members { get; set; }
        public List<VM_Admin>? Admins { get; set; }
        public List<AllStatus>? Statuses { get; set; }
        public string? Message { get; set; }
        public bool State { get; set; }
    }
}