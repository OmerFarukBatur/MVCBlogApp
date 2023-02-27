using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.GeneralOptions.Navigation.GetAllNavigation
{
    public class GetAllNavigationQueryHandler : IRequestHandler<GetAllNavigationQueryRequest, GetAllNavigationQueryResponse>
    {
        private readonly IGeneralOptionsService _generalOptions;

        public GetAllNavigationQueryHandler(IGeneralOptionsService generalOptions)
        {
            _generalOptions = generalOptions;
        }

        public async Task<GetAllNavigationQueryResponse> Handle(GetAllNavigationQueryRequest request, CancellationToken cancellationToken)
        {
            return await _generalOptions.GetAllNavigationAsync();
        }
    }
}
