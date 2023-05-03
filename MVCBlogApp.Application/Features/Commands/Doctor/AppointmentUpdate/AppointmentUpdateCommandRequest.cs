using MediatR;
using System.ComponentModel.DataAnnotations;

namespace MVCBlogApp.Application.Features.Commands.Doctor.AppointmentUpdate
{
    public class AppointmentUpdateCommandRequest : IRequest<AppointmentUpdateCommandResponse>
    {
        public int Id { get; set; }
        public int MembersId { get; set; }
        [DataType(DataType.Date)]
        public DateTime AppointmentDate { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime AppointmentTime { get; set; }
        public decimal Price { get; set; }
        public string? Subject { get; set; }
        public string? Description { get; set; }
        public int StatusId { get; set; }
        public int UserId { get; set; }
    }
}