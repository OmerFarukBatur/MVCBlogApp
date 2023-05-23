using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Doctor.Diseases.DiseasesCreate
{
    public class DiseasesCreateCommandHandler : IRequestHandler<DiseasesCreateCommandRequest, DiseasesCreateCommandResponse>
    {
        private readonly IDoctorReportProccessService _service;

        public DiseasesCreateCommandHandler(IDoctorReportProccessService service)
        {
            _service = service;
        }

        public async Task<DiseasesCreateCommandResponse> Handle(DiseasesCreateCommandRequest request, CancellationToken cancellationToken)
        {
            DiseasesCreateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);

            if (validation.IsValid)
            {
                return await _service.DiseasesCreateAsync(request);
            }
            else
            {
                return new()
                {
                    Message = "Lütfen alanları geçerli değerlerle doldurunuz.",
                    State = false
                };
            }
        }
    }
}
