using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.GeneralOptions.Form.FormCreate
{
    public class FormCreateCommandHandler : IRequestHandler<FormCreateCommandRequest, FormCreateCommandResponse>
    {
        private readonly IGeneralOptionsService _generalOptionsService;

        public FormCreateCommandHandler(IGeneralOptionsService generalOptionsService)
        {
            _generalOptionsService = generalOptionsService;
        }

        public async Task<FormCreateCommandResponse> Handle(FormCreateCommandRequest request, CancellationToken cancellationToken)
        {
            FormCreateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);

            if (validation.IsValid)
            {
                return await _generalOptionsService.FormCreateAsync(request);
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
