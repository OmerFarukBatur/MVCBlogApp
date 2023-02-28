using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.GeneralOptions.Navigation.NavigationDelete
{
    public class NavigationDeleteCommandHandler : IRequestHandler<NavigationDeleteCommandRequest, NavigationDeleteCommandResponse>
    {
        private readonly IGeneralOptionsService _generalOptionsService;

        public NavigationDeleteCommandHandler(IGeneralOptionsService generalOptionsService)
        {
            _generalOptionsService = generalOptionsService;
        }

        public async Task<NavigationDeleteCommandResponse> Handle(NavigationDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _generalOptionsService.NavigationDeleteAsync(request);
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
