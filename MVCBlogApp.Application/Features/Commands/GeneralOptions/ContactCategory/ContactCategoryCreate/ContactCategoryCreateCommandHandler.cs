
using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.GeneralOptions.ContactCategory.ContactCategoryCreate
{
    public class ContactCategoryCreateCommandHandler : IRequestHandler<ContactCategoryCreateCommandRequest, ContactCategoryCreateCommandResponse>
    {
        private readonly IGeneralOptionsService _generalOptionsService;

        public ContactCategoryCreateCommandHandler(IGeneralOptionsService generalOptionsService)
        {
            _generalOptionsService = generalOptionsService;
        }

        public async Task<ContactCategoryCreateCommandResponse> Handle(ContactCategoryCreateCommandRequest request, CancellationToken cancellationToken)
        {
            ContactCategoryCreateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);

            if (validation.IsValid)
            {
                return await _generalOptionsService.ContactCategoryCreateAsync(request);
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
