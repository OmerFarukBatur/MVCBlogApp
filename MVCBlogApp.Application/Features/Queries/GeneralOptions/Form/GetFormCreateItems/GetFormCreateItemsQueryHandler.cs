using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.GeneralOptions.Form.GetFormCreateItems
{
    public class GetFormCreateItemsQueryHandler : IRequestHandler<GetFormCreateItemsQueryRequest, GetFormCreateItemsQueryResponse>
    {
        private readonly IGeneralOptionsService _generalOptionsService;

        public GetFormCreateItemsQueryHandler(IGeneralOptionsService generalOptionsService)
        {
            _generalOptionsService = generalOptionsService;
        }

        public async Task<GetFormCreateItemsQueryResponse> Handle(GetFormCreateItemsQueryRequest request, CancellationToken cancellationToken)
        {
            return await _generalOptionsService.GetFormCreateItemsAsync();
        }
    }
}
