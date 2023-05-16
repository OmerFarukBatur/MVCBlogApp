using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Doctor.Lab.LabCreate
{
    public class LabCreateCommandHandler : IRequestHandler<LabCreateCommandRequest, LabCreateCommandResponse>
    {
        private readonly IDoctorGeneralOptionsService _generalOptionsService;

        public LabCreateCommandHandler(IDoctorGeneralOptionsService generalOptionsService)
        {
            _generalOptionsService = generalOptionsService;
        }

        public async Task<LabCreateCommandResponse> Handle(LabCreateCommandRequest request, CancellationToken cancellationToken)
        {
            LabCreateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);

            if (validation.IsValid)
            {
                return await _generalOptionsService.LabCreateAsync(request);
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
