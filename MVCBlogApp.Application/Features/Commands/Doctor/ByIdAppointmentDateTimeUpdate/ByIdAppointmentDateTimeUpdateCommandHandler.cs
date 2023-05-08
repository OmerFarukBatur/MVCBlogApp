using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Doctor.ByIdAppointmentDateTimeUpdate
{
    public class ByIdAppointmentDateTimeUpdateCommandHandler : IRequestHandler<ByIdAppointmentDateTimeUpdateCommandRequest, ByIdAppointmentDateTimeUpdateCommandResponse>
    {
        private readonly IDoctorReportProccessService _service;

        public ByIdAppointmentDateTimeUpdateCommandHandler(IDoctorReportProccessService service)
        {
            _service = service;
        }

        public async Task<ByIdAppointmentDateTimeUpdateCommandResponse> Handle(ByIdAppointmentDateTimeUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            ByIdAppointmentDateTimeUpdateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);
            if (validation.IsValid)
            {
                return await _service.ByIdAppointmentDateTimeUpdateAsync(request);
            }
            else
            {
                return new()
                {
                    Message = "Kayıt bulunamamıştır.",
                    State = false
                };
            }
        }
    }
}

