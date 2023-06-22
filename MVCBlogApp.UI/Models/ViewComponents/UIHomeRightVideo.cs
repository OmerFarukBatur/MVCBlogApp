using MediatR;
using Microsoft.AspNetCore.Mvc;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Features.Queries.UIHome.UIHomeRightVideo;

namespace MVCBlogApp.UI.Models.ViewComponents
{
    public class UIHomeRightVideo : ViewComponent
    {
        private readonly IOperationService _operationService;
        private readonly IMediator _mediator;

        public UIHomeRightVideo(IOperationService operationService, IMediator mediator)
        {
            _operationService = operationService;
            _mediator = mediator;        
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            UIHomeRightVideoQueryRequest request = new();
            UIHomeRightVideoQueryResponse response = await _mediator.Send(request);


            if (response.LangId == 1) { ViewBag.VTitle = "Videolar"; } else if (response.LangId == 2) { ViewBag.VTitle = "Videos"; }

            return View(response.Video);
        }
    }
}
