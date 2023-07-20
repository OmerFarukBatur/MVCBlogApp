using MediatR;
using Microsoft.AspNetCore.Mvc;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Features.Queries.UIArticle.UILeftNavigation;
using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.UI.Models.ViewComponents
{
    public class UILeftNavigation : ViewComponent
    {
        private readonly IOperationService _operationService;
        private readonly IMediator _mediator;

        public UILeftNavigation(IOperationService operationService, IMediator mediator)
        {
            _operationService = operationService;
            _mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync(UILeftNavigationQueryRequest request)
        {
            UILeftNavigationQueryResponse response = await _mediator.Send(request);

            if (response.LeftNavigations != null)
            {
                return View(response.LeftNavigations);
            }
            else
            {
                return View(new List<VM_Navigation>());
            }
        }
    }
}
