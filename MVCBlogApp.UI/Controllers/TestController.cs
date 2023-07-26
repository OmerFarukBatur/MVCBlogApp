using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Features.Commands.Test.BMICalculateCreate;
using MVCBlogApp.Application.Features.Queries.Test.BMICalculate;

namespace MVCBlogApp.UI.Controllers
{
    public class TestController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IOperationService _operationService;

        public TestController(IMediator mediator, IOperationService operationService)
        {
            _mediator = mediator;
            _operationService = operationService;
        }

        [Route("bmi-hesapla")]
        [Route("bmi-calc")]
        public async Task<IActionResult> BMICalculate()
        {

            int LangID = _operationService.SessionLangId();

            if (LangID == 2)
            {
                TempData["Title"] = "Calc BMI";
            }
            else
            {
                TempData["Title"] = "BMI Hesapla";
            }

            BMICalculateQueryRequest request = new();
            BMICalculateQueryResponse response = await _mediator.Send(request);
            ViewBag.IsForm = true;

            return View(response.BMI);
        }

        [Route("bmi-hesapla")]
        [Route("bmi-calc")]
        [HttpPost]
        public async Task<IActionResult> BMICalculate(BMICalculateCreateCommandRequest request)
        {
            BMICalculateCreateCommandResponse response = await _mediator.Send(request);
            ViewBag.IsForm = false;         

            return View(response.BMI);
        }
    }
}
