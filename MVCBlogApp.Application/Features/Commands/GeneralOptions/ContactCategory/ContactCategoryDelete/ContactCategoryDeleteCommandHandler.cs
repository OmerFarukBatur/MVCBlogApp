
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.GeneralOptions.ContactCategory.ContactCategoryDelete
{
    public class ContactCategoryDeleteCommandHandler : IRequestHandler<ContactCategoryDeleteCommandRequest, ContactCategoryDeleteCommandResponse>
    {
        private readonly IGeneralOptionsService _generalOptionsService;

        public ContactCategoryDeleteCommandHandler(IGeneralOptionsService generalOptionsService)
        {
            _generalOptionsService = generalOptionsService;
        }

        public async Task<ContactCategoryDeleteCommandResponse> Handle(ContactCategoryDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _generalOptionsService.ContactCategoryDeleteAsync(request.Id);
            }
            else
            {
                return new()
                {
                    Message = "Kayıt bulunamamıştır.",
                    State = false
                };
            }
        }
    }
}
