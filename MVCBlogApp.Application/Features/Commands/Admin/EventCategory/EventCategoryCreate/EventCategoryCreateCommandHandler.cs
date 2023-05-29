using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Admin.EventCategory.EventCategoryCreate
{
    public class EventCategoryCreateCommandHandler : IRequestHandler<EventCategoryCreateCommandRequest, EventCategoryCreateCommandResponse>
    {
        private readonly IAdminGeneralProcess _adminGeneralProcess;

        public EventCategoryCreateCommandHandler(IAdminGeneralProcess adminGeneralProcess)
        {
            _adminGeneralProcess = adminGeneralProcess;
        }

        public async Task<EventCategoryCreateCommandResponse> Handle(EventCategoryCreateCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.EventCategoryName != null && request.EventCategoryName != "" && request.EventCategoryName.Length > 1 && request.EventCategoryName.Length < 251)
            {
                return await _adminGeneralProcess.EventCategoryCreateAsync(request);
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
