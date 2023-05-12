using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Doctor.DietList.DietListCreate
{
    public class DietListCreateCommandHandler : IRequestHandler<DietListCreateCommandRequest, DietListCreateCommandResponse>
    {
        private readonly IDoctorGeneralOptionsService _optionsService;

        public DietListCreateCommandHandler(IDoctorGeneralOptionsService optionsService)
        {
            _optionsService = optionsService;
        }

        public async Task<DietListCreateCommandResponse> Handle(DietListCreateCommandRequest request, CancellationToken cancellationToken)
        {
            DietListCreateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);
            if (validation.IsValid)
            {
                return await _optionsService.DietListCreateAsync(request);
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
