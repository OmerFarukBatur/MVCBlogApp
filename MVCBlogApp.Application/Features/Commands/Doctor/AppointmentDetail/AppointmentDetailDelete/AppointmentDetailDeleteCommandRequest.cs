using MediatR;

namespace MVCBlogApp.Application.Features.Commands.Doctor.AppointmentDetail.AppointmentDetailDelete
{
    public class AppointmentDetailDeleteCommandRequest : IRequest<AppointmentDetailDeleteCommandResponse>
    {
        public int Id { get; set; }
    }
}