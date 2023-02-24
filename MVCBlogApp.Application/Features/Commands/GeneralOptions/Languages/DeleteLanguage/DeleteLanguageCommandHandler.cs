using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.GeneralOptions.Languages.DeleteLanguage
{
    public class DeleteLanguageCommandHandler : IRequestHandler<DeleteLanguageCommandRequest, DeleteLanguageCommandResponse>
    {
        private readonly IGeneralOptionsService _generalOptionsService;

        public DeleteLanguageCommandHandler(IGeneralOptionsService generalOptionsService)
        {
            _generalOptionsService = generalOptionsService;
        }

        public async Task<DeleteLanguageCommandResponse> Handle(DeleteLanguageCommandRequest request, CancellationToken cancellationToken)
        {
            return await _generalOptionsService.DeleteLanguageAsync(request);
        }
    }
}
