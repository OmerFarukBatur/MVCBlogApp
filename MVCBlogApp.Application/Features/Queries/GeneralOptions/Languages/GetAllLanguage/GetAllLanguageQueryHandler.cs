using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.GeneralOptions.Languages.GetAllLanguage
{
    public class GetAllLanguageQueryHandler : IRequestHandler<GetAllLanguageQueryRequest, GetAllLanguageQueryResponse>
    {
        private readonly IGeneralOptionsService _generalOptionsService;

        public GetAllLanguageQueryHandler(IGeneralOptionsService generalOptionsService)
        {
            _generalOptionsService = generalOptionsService;
        }

        public async Task<GetAllLanguageQueryResponse> Handle(GetAllLanguageQueryRequest request, CancellationToken cancellationToken)
        {
            return new() { AllLanguages = await _generalOptionsService.GetAllLanguageAsync(request) };
        }
    }
}
