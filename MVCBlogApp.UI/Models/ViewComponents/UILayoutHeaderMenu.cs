using MediatR;
using Microsoft.AspNetCore.Mvc;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Features.Queries.IULayout.UILayoutHeaderMenu;

namespace MVCBlogApp.UI.Models.ViewComponents
{
    public class UILayoutHeaderMenu : ViewComponent
    {
        private readonly IMediator _mediator;
        private readonly IOperationService _operationService;

        public UILayoutHeaderMenu(IMediator mediator, IOperationService operationService)
        {
            _mediator = mediator;
            _operationService = operationService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            UILayoutHeaderMenuQueryRequest request = new();
            UILayoutHeaderMenuQueryResponse response = await _mediator.Send(request);
            return View(response.Navigations);
        }
    }
}
