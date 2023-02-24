using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.GeneralOptions.Languages.UpdateLanguage
{
    public class UpdateLanguageCommandHandler : IRequestHandler<UpdateLanguageCommandRequest, UpdateLanguageCommandResponse>
    {
        private readonly IGeneralOptionsService _generalOptionsService;

        public UpdateLanguageCommandHandler(IGeneralOptionsService generalOptionsService)
        {
            _generalOptionsService = generalOptionsService;
        }

        public async Task<UpdateLanguageCommandResponse> Handle(UpdateLanguageCommandRequest request, CancellationToken cancellationToken)
        {
            UpdateLanguageCommandValidator validations = new();
            ValidationResult validation = validations.Validate(request);

            if (validation.IsValid)
            {
                return await _generalOptionsService.UpdateLanguageAsync(request);
            }
            else
            {
                return new()
                {
                    Message = "Lütfen geçerli değerler giriniz.",
                    State = false
                };
            }
        }
    }
}
