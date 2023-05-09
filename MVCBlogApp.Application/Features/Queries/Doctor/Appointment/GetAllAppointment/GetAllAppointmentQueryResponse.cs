using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.Doctor.Appointment.GetAllAppointment
{
    public class GetAllAppointmentQueryResponse
    {
        public List<VM_D_Appointment> D_Appointments { get; set; }
    }
}