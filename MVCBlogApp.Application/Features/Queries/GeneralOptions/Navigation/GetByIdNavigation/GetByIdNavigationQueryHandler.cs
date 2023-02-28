using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.GeneralOptions.Navigation.GetByIdNavigation
{
    public class GetByIdNavigationQueryHandler : IRequestHandler<GetByIdNavigationQueryRequest, GetByIdNavigationQueryResponse>
    {
        private readonly IGeneralOptionsService _generalOptionsService;

        public GetByIdNavigationQueryHandler(IGeneralOptionsService generalOptionsService)
        {
            _generalOptionsService = generalOptionsService;
        }

        public async Task<GetByIdNavigationQueryResponse> Handle(GetByIdNavigationQueryRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _generalOptionsService.GetByIdNavigationAsync(request);
            }
            else
            {
                return new()
                {
                    State = false
                };
            }
        }
    }
}
