using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Doctor.AppointmentDetail.AppointmentDetailUpdate
{
    public class AppointmentDetailUpdateCommandHandler : IRequestHandler<AppointmentDetailUpdateCommandRequest, AppointmentDetailUpdateCommandResponse>
    {
        private readonly IDoctorReportProccessService _service;

        public AppointmentDetailUpdateCommandHandler(IDoctorReportProccessService service)
        {
            _service = service;
        }

        public async Task<AppointmentDetailUpdateCommandResponse> Handle(AppointmentDetailUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            AppointmentDetailUpdateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);

            if (validation.IsValid)
            {
                return await _service.AppointmentDetailUpdateAsync(request);
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
