using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Commands.GeneralOptions.CreateLanguage
{
    public class CreateLanguageCommandHandler : IRequestHandler<CreateLanguageCommandRequest, CreateLanguageCommandResponse>
    {
        private readonly IGeneralOptionsService _generalOptionsService;

        public CreateLanguageCommandHandler(IGeneralOptionsService generalOptionsService)
        {
            _generalOptionsService = generalOptionsService;
        }

        public async Task<CreateLanguageCommandResponse> Handle(CreateLanguageCommandRequest request, CancellationToken cancellationToken)
        {
            CreateLanguageCommandValidator validations = new();
            ValidationResult result = validations.Validate(new VM_Language() { Language = request.Language });
            
            if (result.IsValid)
            {
                return await _generalOptionsService.CreateLanguageAsync(request);
            }
            else
            {
                return new()
                {
                    Message = "Lütfen geçerli veriler giriniz.",
                    State = false
                };
            }
        }
    }
}
