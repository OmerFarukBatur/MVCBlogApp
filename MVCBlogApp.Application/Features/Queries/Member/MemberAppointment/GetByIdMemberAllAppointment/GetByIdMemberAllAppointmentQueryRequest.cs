using MediatR;

namespace MVCBlogApp.Application.Features.Queries.Member.MemberAppointment.GetByIdMemberAllAppointment
{
    public class GetByIdMemberAllAppointmentQueryRequest : IRequest<GetByIdMemberAllAppointmentQueryResponse>
    {
        public int MemberId { get; set; }
    }
}