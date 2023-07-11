using MediatR;
using Microsoft.AspNetCore.Mvc;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Features.Queries.IULayout.UILayoutBanner;

namespace MVCBlogApp.UI.Models.ViewComponents
{
    public class UILayoutBanner : ViewComponent
    {
        private readonly IMediator _mediator;
        private readonly IOperationService _operationService;

        public UILayoutBanner(IMediator mediator, IOperationService operationService)
        {
            _mediator = mediator;
            _operationService = operationService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            UILayoutBannerQueryRequest request = new();
            UILayoutBannerQueryResponse response = await _mediator.Send(request);

            ViewBag.ImageUrl = response.BannerUrl;

            return View();
        }
    }
}
