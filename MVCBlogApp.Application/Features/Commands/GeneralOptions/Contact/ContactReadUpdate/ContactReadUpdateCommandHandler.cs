using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.GeneralOptions.Contact.ContactReadUpdate
{
    public class ContactReadUpdateCommandHandler : IRequestHandler<ContactReadUpdateCommandRequest, ContactReadUpdateCommandResponse>
    {
        private readonly IGeneralOptionsService _generalOptionsService;

        public ContactReadUpdateCommandHandler(IGeneralOptionsService generalOptionsService)
        {
            _generalOptionsService = generalOptionsService;
        }

        public async Task<ContactReadUpdateCommandResponse> Handle(ContactReadUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _generalOptionsService.ContactReadUpdateAsync(request.Id);
            }
            else
            {
                return new()
                {
                    State = false,
                    Message = "Kayıt bulunamamıştır."
                };
            }
        }
    }
}
