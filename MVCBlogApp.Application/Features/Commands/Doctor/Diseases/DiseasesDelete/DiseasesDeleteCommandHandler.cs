using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Doctor.Diseases.DiseasesDelete
{
    public class DiseasesDeleteCommandHandler : IRequestHandler<DiseasesDeleteCommandRequest, DiseasesDeleteCommandResponse>
    {
        private readonly IDoctorReportProccessService _service;

        public DiseasesDeleteCommandHandler(IDoctorReportProccessService service)
        {
            _service = service;
        }

        public async Task<DiseasesDeleteCommandResponse> Handle(DiseasesDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _service.DiseasesDeleteAsync(request.Id);
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
