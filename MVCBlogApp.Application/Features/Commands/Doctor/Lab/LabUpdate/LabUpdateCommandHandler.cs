using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Doctor.Lab.LabUpdate
{
    public class LabUpdateCommandHandler : IRequestHandler<LabUpdateCommandRequest, LabUpdateCommandResponse>
    {
        private readonly IDoctorGeneralOptionsService _optionsService;

        public LabUpdateCommandHandler(IDoctorGeneralOptionsService optionsService)
        {
            _optionsService = optionsService;
        }

        public async Task<LabUpdateCommandResponse> Handle(LabUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            LabUpdateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);

            if (validation.IsValid)
            {
                return await _optionsService.LabUpdateAsync(request);
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
