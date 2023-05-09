using MediatR;
using System.ComponentModel.DataAnnotations;

namespace MVCBlogApp.Application.Features.Commands.Doctor.Appointment.ByIdAppointmentDateTimeUpdate
{
    public class ByIdAppointmentDateTimeUpdateCommandRequest : IRequest<ByIdAppointmentDateTimeUpdateCommandResponse>
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime AppointmentDate { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime AppointmentTime { get; set; }
    }
}