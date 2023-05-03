using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Doctor.AppointmentUpdate
{
    public class AppointmentUpdateCommandHandler : IRequestHandler<AppointmentUpdateCommandRequest, AppointmentUpdateCommandResponse>
    {
        private readonly IDoctorReportProccessService _service;

        public AppointmentUpdateCommandHandler(IDoctorReportProccessService service)
        {
            _service = service;
        }

        public async Task<AppointmentUpdateCommandResponse> Handle(AppointmentUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            AppointmentUpdateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);
            if (validation.IsValid)
            {
                return await _service.AppointmentUpdateAsync(request);
            }
            else
            {
                return new()
                {
                    Message = "Lütfen alanları geçerli bilgilerle doldurunuz.",
                    State = false
                };
            }
        }
    }
}
