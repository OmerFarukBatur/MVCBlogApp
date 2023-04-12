using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.UserIslemleri.MemberAppointment.GetAllMemberAppointment
{
    public class GetAllMemberAppointmentQueryHandler : IRequestHandler<GetAllMemberAppointmentQueryRequest, GetAllMemberAppointmentQueryResponse>
    {
        private readonly IUserIslemleriService _userIslemleriService;

        public GetAllMemberAppointmentQueryHandler(IUserIslemleriService userIslemleriService)
        {
            _userIslemleriService = userIslemleriService;
        }

        public async Task<GetAllMemberAppointmentQueryResponse> Handle(GetAllMemberAppointmentQueryRequest request, CancellationToken cancellationToken)
        {
            return await _userIslemleriService.GetAllMemberAppointmentAsync();
        }
    }
}
