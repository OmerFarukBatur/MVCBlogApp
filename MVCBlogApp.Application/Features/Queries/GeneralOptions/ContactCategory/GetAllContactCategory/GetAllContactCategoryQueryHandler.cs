using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.GeneralOptions.ContactCategory.GetAllContactCategory
{
    public class GetAllContactCategoryQueryHandler : IRequestHandler<GetAllContactCategoryQueryRequest, GetAllContactCategoryQueryResponse>
    {
        private readonly IGeneralOptionsService _generalOptionsService;

        public GetAllContactCategoryQueryHandler(IGeneralOptionsService generalOptionsService)
        {
            _generalOptionsService = generalOptionsService;
        }

        public async Task<GetAllContactCategoryQueryResponse> Handle(GetAllContactCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            return await _generalOptionsService.GetAllContactCategoryAsync();
        }
    }
}
