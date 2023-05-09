using MediatR;

namespace MVCBlogApp.Application.Features.Queries.Doctor.AppointmentDetail.GetByIdAppointmentDetail
{
    public class GetByIdAppointmentDetailQueryRequest : IRequest<GetByIdAppointmentDetailQueryResponse>
    {
        public int Id { get; set; }
    }
}