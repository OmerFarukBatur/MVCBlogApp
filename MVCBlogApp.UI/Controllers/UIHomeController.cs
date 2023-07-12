using MediatR;
using Microsoft.AspNetCore.Mvc;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Features.Commands.IUHome.UploadImage;
using MVCBlogApp.Application.Features.Queries.UIHome.UIHomeIndex;

namespace MVCBlogApp.UI.Controllers
{
    public class UIHomeController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IOperationService _operationService;

        public UIHomeController(IMediator mediator, IOperationService operationService)
        {
            _mediator = mediator;
            _operationService = operationService;
        }

        public async Task<IActionResult> Index()
        {
            UIHomeIndexQueryRequest request = new();
            UIHomeIndexQueryResponse response = await _mediator.Send(request);

            if (response.LangId == 2)
            {

                TempData["Title"] = "Taylan Kümeli | Diet and Nutrition Programs for a Healthy and Balanced Life";
            }
            else
            {

                TempData["Title"] = "Taylan Kümeli | Sağlıklı ve Dengede Bir Yaşam İçin Diyet ve Beslenme Programları";
            }

            if (response.TaylanK == null)
            {
                return NotFound();
            }
            else
            {
                TempData["MetaKey"] = response.TaylanK.Metakey;
                TempData["MetaDescription"] = response.TaylanK.Metadescription;
                TempData["MetaTitle"] = response.TaylanK.Metatitle;                
            }
            return View();
        }

        [Route("upload-image")]
        [HttpPost]
        public async Task<IActionResult> UploadImage(UploadImageCommandRequest request)
        {
            UploadImageCommandResponse response = await _mediator.Send(request);
            return Json(response.LocalUploadFile);
        }
    }
}
