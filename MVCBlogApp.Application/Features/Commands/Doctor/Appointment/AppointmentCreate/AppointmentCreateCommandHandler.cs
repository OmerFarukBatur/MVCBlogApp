using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Doctor.Appointment.AppointmentCreate
{
    public class AppointmentCreateCommandHandler : IRequestHandler<AppointmentCreateCommandRequest, AppointmentCreateCommandResponse>
    {
        private readonly IDoctorReportProccessService _service;

        public AppointmentCreateCommandHandler(IDoctorReportProccessService service)
        {
            _service = service;
        }

        public async Task<AppointmentCreateCommandResponse> Handle(AppointmentCreateCommandRequest request, CancellationToken cancellationToken)
        {
            AppointmentCreateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);
            if (validation.IsValid)
            {
                return await _service.AppointmentCreateAsync(request);
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
