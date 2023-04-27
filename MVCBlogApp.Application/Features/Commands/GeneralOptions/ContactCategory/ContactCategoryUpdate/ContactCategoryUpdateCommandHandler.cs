using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.GeneralOptions.ContactCategory.ContactCategoryUpdate
{
    public class ContactCategoryUpdateCommandHandler : IRequestHandler<ContactCategoryUpdateCommandRequest, ContactCategoryUpdateCommandResponse>
    {
        private readonly IGeneralOptionsService _generalOptionsService;

        public ContactCategoryUpdateCommandHandler(IGeneralOptionsService generalOptionsService)
        {
            _generalOptionsService = generalOptionsService;
        }

        public async Task<ContactCategoryUpdateCommandResponse> Handle(ContactCategoryUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            ContactCategoryUpdateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);

            if (validation.IsValid)
            {
                return await _generalOptionsService.ContactCategoryUpdateAsync(request);
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
