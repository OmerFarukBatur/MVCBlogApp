using MediatR;
using Microsoft.AspNetCore.Mvc;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Features.Queries.IULayout.UILayoutHeaderTopMenu;

namespace MVCBlogApp.UI.Models.ViewComponents
{
    public class UILayoutHeaderTopMenu : ViewComponent
    {
        private readonly IMediator _mediator;
        private readonly IOperationService _operationService;

        public UILayoutHeaderTopMenu(IMediator mediator, IOperationService operationService)
        {
            _mediator = mediator;
            _operationService = operationService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            UILayoutHeaderTopMenuQueryRequest request = new();
            UILayoutHeaderTopMenuQueryResponse response = await _mediator.Send(request);
            return View(response.NameSurname);
        }
    }
}
