using MediatR;
using Microsoft.AspNetCore.Mvc;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Features.Queries.UIPress.MedyaYansimalariPartialView;
using MVCBlogApp.Application.Helpers;
using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.UI.Controllers
{
    public class PressController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IOperationService _operationService;

        public PressController(IMediator mediator, IOperationService operationService)
        {
            _mediator = mediator;
            _operationService = operationService;
        }

        [Route("medya-yansimalari")]
        [Route("media-Images")]
        public IActionResult Index()
        {
            int LangID = _operationService.SessionLangId();

            if (LangID == 2)
            {
                TempData["Title"] = "Media Images";

            }
            else
            {
                TempData["Title"] = "Medya Yansımaları";

            }

            return View();
        }

        [Route("medya-yansimalari-partial-view")]
        [HttpPost]
        public async Task<JsonResult> MedyaYansimalariPartialView(MedyaYansimalariPartialViewQueryRequest request)
        {
            MedyaYansimalariPartialViewQueryResponse response = await _mediator.Send(request);

            VM_ReturnViewString r = new();
            r.Status = 200;
            r.ViewString = this.RenderViewAsync("MedyaYansimalariPartialView", response.Result, true).Result;
            return Json(r);
        }
    }
}
