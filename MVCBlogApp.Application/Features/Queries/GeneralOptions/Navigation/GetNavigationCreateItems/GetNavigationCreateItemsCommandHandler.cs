using MediatR;
using MVCBlogApp.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCBlogApp.Application.Features.Queries.GeneralOptions.Navigation.GetNavigationCreateItems
{
    public class GetNavigationCreateItemsCommandHandler : IRequestHandler<GetNavigationCreateItemsCommandRequest, GetNavigationCreateItemsCommandResponse>
    {
        private readonly IGeneralOptionsService _generalOptionsService;

        public GetNavigationCreateItemsCommandHandler(IGeneralOptionsService generalOptionsService)
        {
            _generalOptionsService = generalOptionsService;
        }

        public async Task<GetNavigationCreateItemsCommandResponse> Handle(GetNavigationCreateItemsCommandRequest request, CancellationToken cancellationToken)
        {
            return await _generalOptionsService.GetNavigationCreateItemsAsync();
        }
    }
}
