using MediatR;

namespace MVCBlogApp.Application.Features.Commands.Doctor.AppointmentDetail.AppointmentDetailCreate
{
    public class AppointmentDetailCreateCommandRequest : IRequest<AppointmentDetailCreateCommandResponse>
    {
        public int AppointmentId { get; set; }
        public int MembersId { get; set; }
        public int UserId { get; set; }
        public string Diagnosis { get; set; }
        public string History { get; set; }
        public string Treatment { get; set; }
        public decimal Weight { get; set; }
        public decimal Size { get; set; }
        public decimal OilRate { get; set; }
    }
}