using MediatR;
using Microsoft.AspNetCore.Mvc;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Features.Queries.IUWorkShop.GetWhereWorkShop;

namespace MVCBlogApp.UI.Controllers
{
    public class UIWorkshopController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IOperationService _operationService;

        public UIWorkshopController(IMediator mediator, IOperationService operationService)
        {
            _mediator = mediator;
            _operationService = operationService;
        }

        [Route("seminer-etkinlik-takvimi")]
        [Route("seminar-event-calendar")]
        public async Task<IActionResult> Index()
        {
            int LangID = _operationService.SessionLangId();

            if (LangID == 2)
            {
                TempData["MetaKey"] = "Seminar Event Calendar";
                TempData["MetaDescription"] = "Seminar Event Calendar";
                TempData["MetaTitle"] = "Seminar Event Calendar";
                TempData["Title"] = "Seminar Event Calendar";

            }
            else
            {
                TempData["MetaKey"] = "Seminer Etkinlik Takvimi";
                TempData["MetaDescription"] = "Seminer Etkinlik Takvimi";
                TempData["MetaTitle"] = "Seminer Etkinlik Takvimi";
                TempData["Title"] = "Seminer Etkinlik Takvimi";
            }

            GetWhereWorkShopQueryRequest request = new();
            GetWhereWorkShopQueryResponse response = await _mediator.Send(request);

            return View(response.Workshops);

        }
    }
}
