using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Doctor.Examination.ExaminationDelete
{
    public class ExaminationDeleteCommandHandler : IRequestHandler<ExaminationDeleteCommandRequest, ExaminationDeleteCommandResponse>
    {
        private readonly IDoctorGeneralOptionsService _doctorGeneralOptionsService;

        public ExaminationDeleteCommandHandler(IDoctorGeneralOptionsService doctorGeneralOptionsService)
        {
            _doctorGeneralOptionsService = doctorGeneralOptionsService;
        }

        public async Task<ExaminationDeleteCommandResponse> Handle(ExaminationDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _doctorGeneralOptionsService.ExaminationDeleteAsync(request.Id);
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
