using MediatR;
using Microsoft.AspNetCore.Mvc;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Features.Queries.UIHome.UIHomeSLeftNavigation;

namespace MVCBlogApp.UI.Models.ViewComponents
{
    public class UIHomeSLeftNavigation : ViewComponent
    {
        private readonly IOperationService _operationService;
        private readonly IMediator _mediator;

        public UIHomeSLeftNavigation(IOperationService operationService, IMediator mediator)
        {
            _operationService = operationService;
            _mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            UIHomeSLeftNavigationQueryRequest request = new();
            UIHomeSLeftNavigationQueryResponse response = await _mediator.Send(request);

            return View(response.SLeftNavigations);
        }
    }
}
