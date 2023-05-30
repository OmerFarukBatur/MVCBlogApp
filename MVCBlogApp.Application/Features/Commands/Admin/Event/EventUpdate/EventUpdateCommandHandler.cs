using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Admin.Event.EventUpdate
{
    public class EventUpdateCommandHandler : IRequestHandler<EventUpdateCommandRequest, EventUpdateCommandResponse>
    {
        private readonly IAdminGeneralProcess _adminGeneralProcess;

        public EventUpdateCommandHandler(IAdminGeneralProcess adminGeneralProcess)
        {
            _adminGeneralProcess = adminGeneralProcess;
        }

        public async Task<EventUpdateCommandResponse> Handle(EventUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            EventUpdateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);

            if (validation.IsValid)
            {
                return await _adminGeneralProcess.EventUpdateAsync(request);
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
