using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Doctor.DietList.DietListUpdate
{
    public class DietListUpdateCommandHandler : IRequestHandler<DietListUpdateCommandRequest, DietListUpdateCommandResponse>
    {
        private readonly IDoctorGeneralOptionsService _optionsService;

        public DietListUpdateCommandHandler(IDoctorGeneralOptionsService optionsService)
        {
            _optionsService = optionsService;
        }

        public async Task<DietListUpdateCommandResponse> Handle(DietListUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            DietListUpdateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);
            if (validation.IsValid)
            {
                return await _optionsService.DietListUpdateAsync(request);
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
