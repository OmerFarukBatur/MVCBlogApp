using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Doctor.AppointmentDelete
{
    public class AppointmentDeleteCommandHandler : IRequestHandler<AppointmentDeleteCommandRequest, AppointmentDeleteCommandResponse>
    {
        private readonly IDoctorReportProccessService _doctorReportProccessService;

        public AppointmentDeleteCommandHandler(IDoctorReportProccessService doctorReportProccessService)
        {
            _doctorReportProccessService = doctorReportProccessService;
        }

        public async Task<AppointmentDeleteCommandResponse> Handle(AppointmentDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _doctorReportProccessService.AppointmentDeleteAsync(request.Id);
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
