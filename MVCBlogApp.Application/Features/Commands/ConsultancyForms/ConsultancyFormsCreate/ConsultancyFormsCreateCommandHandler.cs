using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.ConsultancyForms.ConsultancyFormsCreate
{
    public class ConsultancyFormsCreateCommandHandler : IRequestHandler<ConsultancyFormsCreateCommandRequest, ConsultancyFormsCreateCommandResponse>
    {
        private readonly IUIOtherService _service;

        public ConsultancyFormsCreateCommandHandler(IUIOtherService service)
        {
            _service = service;
        }

        public async Task<ConsultancyFormsCreateCommandResponse> Handle(ConsultancyFormsCreateCommandRequest request, CancellationToken cancellationToken)
        {
            ConsultancyFormsCreateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);

            if (validation.IsValid)
            {
                return await _service.ConsultancyFormsCreateAsync(request);
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
