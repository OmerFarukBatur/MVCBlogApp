using MediatR;

namespace MVCBlogApp.Application.Features.Queries.Doctor.Appointment.GetByIdAppointment
{
    public class GetByIdAppointmentQueryRequest : IRequest<GetByIdAppointmentQueryResponse>
    {
        public int Id { get; set; }
    }
}