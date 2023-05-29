using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Admin.EventCategory.EventCategoryUpdate
{
    public class EventCategoryUpdateCommandHandler : IRequestHandler<EventCategoryUpdateCommandRequest, EventCategoryUpdateCommandResponse>
    {
        private readonly IAdminGeneralProcess _adminGeneralProcess;

        public EventCategoryUpdateCommandHandler(IAdminGeneralProcess adminGeneralProcess)
        {
            _adminGeneralProcess = adminGeneralProcess;
        }

        public async Task<EventCategoryUpdateCommandResponse> Handle(EventCategoryUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.EventCategoryName != null && request.EventCategoryName != "" && request.EventCategoryName.Length > 1 && request.EventCategoryName.Length < 251)
            {
                return await _adminGeneralProcess.EventCategoryUpdateAsync(request);
            }
            else
            {
                return new()
                {
                    Message = "Lütfen alanları geçerli değerlerle doldurunuz.",
                    State = false
                };
            }
        }
    }
}
