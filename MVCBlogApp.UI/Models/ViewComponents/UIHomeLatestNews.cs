using MediatR;
using Microsoft.AspNetCore.Mvc;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Features.Queries.UIHome.UIHomeLatestNews;

namespace MVCBlogApp.UI.Models.ViewComponents
{
    public class UIHomeLatestNews : ViewComponent
    {
        private readonly IOperationService _operationService;
        private readonly IMediator _mediator;

        public UIHomeLatestNews(IOperationService operationService, IMediator mediator)
        {
            _operationService = operationService;
            _mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            UIHomeLatestNewsQueryRequest request = new();
            UIHomeLatestNewsQueryResponse response = await _mediator.Send(request);

            if (response.LangId == 1)
            {
                ViewBag.Title = "Güncel Haberler";
            }
            else if (response.LangId == 2)
            {
                ViewBag.Title = "Lastest News";
            }

            return View(response.LatestNews);
        }
    }
}
