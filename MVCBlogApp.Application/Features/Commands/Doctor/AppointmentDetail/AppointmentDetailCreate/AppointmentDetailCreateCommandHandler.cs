using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Doctor.AppointmentDetail.AppointmentDetailCreate
{
    public class AppointmentDetailCreateCommandHandler : IRequestHandler<AppointmentDetailCreateCommandRequest, AppointmentDetailCreateCommandResponse>
    {
        private readonly IDoctorReportProccessService _service;

        public AppointmentDetailCreateCommandHandler(IDoctorReportProccessService service)
        {
            _service = service;
        }

        public async Task<AppointmentDetailCreateCommandResponse> Handle(AppointmentDetailCreateCommandRequest request, CancellationToken cancellationToken)
        {
            AppointmentDetailCreateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);

            if (validation.IsValid)
            {
                return await _service.AppointmentDetailCreateAsync(request);
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
