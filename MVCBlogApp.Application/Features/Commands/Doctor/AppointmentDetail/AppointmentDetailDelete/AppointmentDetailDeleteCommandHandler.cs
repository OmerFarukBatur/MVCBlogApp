using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Doctor.AppointmentDetail.AppointmentDetailDelete
{
    public class AppointmentDetailDeleteCommandHandler : IRequestHandler<AppointmentDetailDeleteCommandRequest, AppointmentDetailDeleteCommandResponse>
    {
        private readonly IDoctorReportProccessService _service;

        public AppointmentDetailDeleteCommandHandler(IDoctorReportProccessService service)
        {
            _service = service;
        }

        public async Task<AppointmentDetailDeleteCommandResponse> Handle(AppointmentDetailDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _service.AppointmentDetailDeleteAsync(request.Id);
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
