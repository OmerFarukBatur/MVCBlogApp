using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Doctor.AppointmentDetail.GetByIdAppointmentDetail
{
    public class GetByIdAppointmentDetailQueryHandler : IRequestHandler<GetByIdAppointmentDetailQueryRequest, GetByIdAppointmentDetailQueryResponse>
    {
        private readonly IDoctorReportProccessService _doctorReportProccessService;

        public GetByIdAppointmentDetailQueryHandler(IDoctorReportProccessService doctorReportProccessService)
        {
            _doctorReportProccessService = doctorReportProccessService;
        }

        public async Task<GetByIdAppointmentDetailQueryResponse> Handle(GetByIdAppointmentDetailQueryRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _doctorReportProccessService.GetByIdAppointmentDetailQueryResponse(request.Id);
            }
            else
            {
                return new()
                {
                    Admins = null,
                    Members = null,
                    D_Appointments = null,
                    AppointmentDetail = null,
                    State = false,
                    Message = "Kayıt bulunamamıştır."
                };
            }
        }
    }
}
