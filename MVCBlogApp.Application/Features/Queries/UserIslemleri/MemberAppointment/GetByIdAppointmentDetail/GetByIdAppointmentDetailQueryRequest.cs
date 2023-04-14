using MediatR;

namespace MVCBlogApp.Application.Features.Queries.UserIslemleri.MemberAppointment.GetByIdAppointmentDetail
{
    public class GetByIdAppointmentDetailQueryRequest : IRequest<GetByIdAppointmentDetailQueryResponse>
    {
        public int Id { get; set; }
    }
}