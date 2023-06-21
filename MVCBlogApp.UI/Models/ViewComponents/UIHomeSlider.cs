using MediatR;
using Microsoft.AspNetCore.Mvc;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Features.Queries.UIHome.UIHomeSlider;

namespace MVCBlogApp.UI.Models.ViewComponents
{
    public class UIHomeSlider : ViewComponent
    {
        private readonly IOperationService _operationService;
        private readonly IMediator _mediator;

        public UIHomeSlider(IOperationService operationService, IMediator mediator)
        {
            _operationService = operationService;
            _mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            UIHomeSliderQueryRequest request = new();
            UIHomeSliderQueryResponse response = await _mediator.Send(request);
            return View(response.Carousels);
        }
    }
}
