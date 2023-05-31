using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Admin.Calendar.GetAllCalendarEvent
{
    public class GetAllCalendarEventQueryHandler : IRequestHandler<GetAllCalendarEventQueryRequest, GetAllCalendarEventQueryResponse>
    {
        private readonly IAdminGeneralProcess _adminGeneralProcess;

        public GetAllCalendarEventQueryHandler(IAdminGeneralProcess adminGeneralProcess)
        {
            _adminGeneralProcess = adminGeneralProcess;
        }

        public async Task<GetAllCalendarEventQueryResponse> Handle(GetAllCalendarEventQueryRequest request, CancellationToken cancellationToken)
        {
            return await _adminGeneralProcess.GetAllCalendarEventAsync();
        }
    }
}
