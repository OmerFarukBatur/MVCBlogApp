using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.GeneralOptions.ContactCategory.GetContactCategoryCreateItems
{
    public class GetContactCategoryCreateItemsQueryHandler : IRequestHandler<GetContactCategoryCreateItemsQueryRequest, GetContactCategoryCreateItemsQueryResponse>
    {
        private readonly IGeneralOptionsService _generalOptionsService;

        public GetContactCategoryCreateItemsQueryHandler(IGeneralOptionsService generalOptionsService)
        {
            _generalOptionsService = generalOptionsService;
        }

        public async Task<GetContactCategoryCreateItemsQueryResponse> Handle(GetContactCategoryCreateItemsQueryRequest request, CancellationToken cancellationToken)
        {
            return await _generalOptionsService.GetContactCategoryCreateItemsAsync();
        }
    }
}
