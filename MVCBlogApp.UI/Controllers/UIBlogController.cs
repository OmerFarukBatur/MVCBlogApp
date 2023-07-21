using MediatR;
using Microsoft.AspNetCore.Mvc;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Features.Queries.UIBlog.UIBlogPartialView;
using MVCBlogApp.Application.Helpers;
using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.UI.Controllers
{
    public class UIBlogController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IOperationService _operationService;

        public UIBlogController(IMediator mediator, IOperationService operationService)
        {
            _mediator = mediator;
            _operationService = operationService;
        }

        public IActionResult Index()
        {
            int LangID = _operationService.SessionLangId();

            if (LangID == 2)
            {
                TempData["Title"] = "Blog";

            }
            else
            {
                TempData["Title"] = "Blog";

            }
            return View();
        }

        [Route("blog-partial-view")]
        [HttpPost]
        public async Task<JsonResult> BlogPartialView(UIBlogPartialViewQueryRequest request)
        {
            UIBlogPartialViewQueryResponse response = await _mediator.Send(request);

            VM_ReturnViewString r = new();
            r.Status = 200;
            r.ViewString = this.RenderViewAsync("BlogPartialView", response.Result, true).Result;
            return Json(r);
        }
    }
}
