using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Doctor.Diseases.DiseasesUpdate
{
    public class DiseasesUpdateCommandHandler : IRequestHandler<DiseasesUpdateCommandRequest, DiseasesUpdateCommandResponse>
    {
        private readonly IDoctorReportProccessService _service;

        public DiseasesUpdateCommandHandler(IDoctorReportProccessService service)
        {
            _service = service;
        }

        public async Task<DiseasesUpdateCommandResponse> Handle(DiseasesUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            DiseasesUpdateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);

            if (validation.IsValid)
            {
                return await _service.DiseasesUpdateAsync(request);
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
