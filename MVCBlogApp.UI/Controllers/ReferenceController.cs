using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.Reference.GetAllReference;
using MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.Reference.ReferenceCreate;
using MVCBlogApp.Application.Features.Queries.ReferenceAndOuther.Reference.GetReferenceCreateItems;

namespace MVCBlogApp.UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ReferenceController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IOperationService _operationService;

        public ReferenceController(IMediator mediator, IOperationService operationService)
        {
            _mediator = mediator;
            _operationService = operationService;
        }

        #region Reference

        [HttpGet]
        public async Task<IActionResult> ReferenceList(GetAllReferenceQueryRequest request)
        {
            GetAllReferenceQueryResponse response = await _mediator.Send(request);
            return View(response.References);
        }

        [HttpGet]
        public async Task<IActionResult> ReferenceCreate(GetReferenceCreateItemsQueryRequest request)
        {
            GetReferenceCreateItemsQueryResponse response = await _mediator.Send(request);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> ReferenceCreate(ReferenceCreateCommandRequest request)
        {
            request.CreatedUserId = _operationService.GetUser().Id;
            ReferenceCreateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("ReferenceList", "Reference");
            }
            else
            {
                return RedirectToAction("ReferenceCreate", "Reference");
            }
        }

        [HttpGet]
        public async Task<IActionResult> ReferenceUpdate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ReferenceUpdate(int a)
        {
            return View();
        }

        public async Task<IActionResult> ReferenceDelete(int a)
        {
            return View();
        }

        #endregion

        #region RoxyFileman

        [HttpGet]
        public async Task<IActionResult> RoxyFilemanIndex()
        {
            return View();
        }

        #endregion

        #region SeminarVisuals

        [HttpGet]
        public async Task<IActionResult> SeminarVisualsList()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> SeminarVisualsCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SeminarVisualsCreate(int a)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> SeminarVisualsUpdate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SeminarVisualsUpdate(int a)
        {
            return View();
        }

        public async Task<IActionResult> SeminarVisualsDelete(int a)
        {
            return View();
        }

        #endregion

        #region WorkShopApplicationForms

        [HttpGet]
        public async Task<IActionResult> WSAFList()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> WSAFCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> WSAFCreate(int a)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> WSAFUpdate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> WSAFUpdate(int a)
        {
            return View();
        }

        public async Task<IActionResult> WSAFDelete(int a)
        {
            return View();
        }

        #endregion

        #region Workshop

        [HttpGet]
        public async Task<IActionResult> WorkshopList()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> WorkshopCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> WorkshopCreate(int a)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> WorkshopUpdate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> WorkshopUpdate(int a)
        {
            return View();
        }

        public async Task<IActionResult> WorkshopDelete(int a)
        {
            return View();
        }

        #endregion
    }
}
