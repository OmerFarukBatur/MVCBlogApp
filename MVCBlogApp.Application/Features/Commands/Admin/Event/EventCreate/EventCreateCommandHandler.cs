using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Admin.Event.EventCreate
{
    public class EventCreateCommandHandler : IRequestHandler<EventCreateCommandRequest, EventCreateCommandResponse>
    {
        private readonly IAdminGeneralProcess _adminGeneralProcess;

        public EventCreateCommandHandler(IAdminGeneralProcess adminGeneralProcess)
        {
            _adminGeneralProcess = adminGeneralProcess;
        }

        public async Task<EventCreateCommandResponse> Handle(EventCreateCommandRequest request, CancellationToken cancellationToken)
        {
            EventCreateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);

            if (validation.IsValid)
            {
                return await _adminGeneralProcess.EventCreateAsync(request);
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
