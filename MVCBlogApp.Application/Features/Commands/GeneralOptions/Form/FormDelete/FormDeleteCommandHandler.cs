using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.GeneralOptions.Form.FormDelete
{
    public class FormDeleteCommandHandler : IRequestHandler<FormDeleteCommandRequest, FormDeleteCommandResponse>
    {
        private readonly IGeneralOptionsService _generalOptionsService;

        public FormDeleteCommandHandler(IGeneralOptionsService generalOptionsService)
        {
            _generalOptionsService = generalOptionsService;
        }

        public async Task<FormDeleteCommandResponse> Handle(FormDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _generalOptionsService.FormDeleteAsync(request.Id);
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
