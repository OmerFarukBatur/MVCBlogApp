using MediatR;

namespace MVCBlogApp.Application.Features.Queries.Member.MemberAppointment.GetByIdMemberByIdAppointmentDetail
{
    public class GetByIdMemberByIdAppointmentDetailQueryRequest : IRequest<GetByIdMemberByIdAppointmentDetailQueryResponse>
    {
        public int Id { get; set; }
    }
}