using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.GeneralOptions.Contact.GetAllContact
{
    public class GetAllContactQueryHandler : IRequestHandler<GetAllContactQueryRequest, GetAllContactQueryResponse>
    {
        private readonly IGeneralOptionsService _generalOptionsService;

        public GetAllContactQueryHandler(IGeneralOptionsService generalOptionsService)
        {
            _generalOptionsService = generalOptionsService;
        }

        public async Task<GetAllContactQueryResponse> Handle(GetAllContactQueryRequest request, CancellationToken cancellationToken)
        {
            return await _generalOptionsService.GetAllContactAsync();
        }
    }
}
