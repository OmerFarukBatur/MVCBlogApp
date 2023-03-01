using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.GeneralOptions.Languages.GetByIdLanguage
{
    public class GetByIdLanguageQueryHandler : IRequestHandler<GetByIdLanguageQueryRequest, GetByIdLanguageQueryResponse>
    {
        private readonly IGeneralOptionsService _generalOptionsService;

        public GetByIdLanguageQueryHandler(IGeneralOptionsService generalOptionsService)
        {
            _generalOptionsService = generalOptionsService;
        }

        public async Task<GetByIdLanguageQueryResponse> Handle(GetByIdLanguageQueryRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _generalOptionsService.GetByIdLanguageAsync(request);
            }
            else
            {
                return new()
                {
                    State = false,
                    Language = null
                };
            }
        }
    }
}
