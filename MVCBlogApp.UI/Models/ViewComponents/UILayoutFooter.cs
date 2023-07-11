using MediatR;
using Microsoft.AspNetCore.Mvc;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Features.Queries.IULayout.UILayoutFooter;

namespace MVCBlogApp.UI.Models.ViewComponents
{
    public class UILayoutFooter : ViewComponent
    {
        private readonly IMediator _mediator;
        private readonly IOperationService _operationService;

        public UILayoutFooter(IMediator mediator, IOperationService operationService)
        {
            _mediator = mediator;
            _operationService = operationService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            UILayoutFooterQueryRequest request = new();
            UILayoutFooterQueryResponse response = await _mediator.Send(request);
            return View(response);
        }
    }
}
