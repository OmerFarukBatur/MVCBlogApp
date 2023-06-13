using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Member.MemberAppointment.GetByIdMemberAllAppointment
{
    public class GetByIdMemberAllAppointmentQueryHandler : IRequestHandler<GetByIdMemberAllAppointmentQueryRequest, GetByIdMemberAllAppointmentQueryResponse>
    {
        private readonly IMemberGeneralProcess _process;

        public GetByIdMemberAllAppointmentQueryHandler(IMemberGeneralProcess process)
        {
            _process = process;
        }

        public async Task<GetByIdMemberAllAppointmentQueryResponse> Handle(GetByIdMemberAllAppointmentQueryRequest request, CancellationToken cancellationToken)
        {
            return await _process.GetByIdMemberAllAppointmentAsync(request.MemberId);
        }
    }
}
