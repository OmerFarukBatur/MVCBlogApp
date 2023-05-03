using MediatR;

namespace MVCBlogApp.Application.Features.Queries.Doctor.GetByIdAppointment
{
    public class GetByIdAppointmentQueryRequest : IRequest<GetByIdAppointmentQueryResponse>
    {
        public int Id { get; set; }
    }
}