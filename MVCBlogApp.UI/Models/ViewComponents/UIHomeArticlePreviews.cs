using MediatR;
using Microsoft.AspNetCore.Mvc;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Features.Queries.UIHome.UIHomeArticlePreviews;

namespace MVCBlogApp.UI.Models.ViewComponents
{
    public class UIHomeArticlePreviews : ViewComponent
    {
        private readonly IOperationService _operationService;
        private readonly IMediator _mediator;

        public UIHomeArticlePreviews(IOperationService operationService, IMediator mediator)
        {
            _operationService = operationService;
            _mediator = mediator;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            UIHomeArticlePreviewsQueryRequest request = new();
            UIHomeArticlePreviewsQueryResponse response = await _mediator.Send(request);

            if (response.LangId == 1) { ViewBag.ButtonName = "Hemen İncele"; } else if (response.LangId == 2) { ViewBag.ButtonName = "View"; }

            return View(response.Articles);
        }
    }
}
