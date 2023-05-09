using MediatR;

namespace MVCBlogApp.Application.Features.Commands.Doctor.Appointment.AppointmentDelete
{
    public class AppointmentDeleteCommandRequest : IRequest<AppointmentDeleteCommandResponse>
    {
        public int Id { get; set; }
    }
}