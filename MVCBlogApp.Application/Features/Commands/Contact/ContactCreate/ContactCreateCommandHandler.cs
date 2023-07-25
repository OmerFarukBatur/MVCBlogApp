using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Contact.ContactCreate
{
    public class ContactCreateCommandHandler : IRequestHandler<ContactCreateCommandRequest, ContactCreateCommandResponse>
    {
        private readonly IUIOtherService _service;

        public ContactCreateCommandHandler(IUIOtherService service)
        {
            _service = service;
        }

        public async Task<ContactCreateCommandResponse> Handle(ContactCreateCommandRequest request, CancellationToken cancellationToken)
        {
            ContactCreateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);

            if (validation.IsValid)
            {
                return await _service.ContactCreateAsync(request);
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
