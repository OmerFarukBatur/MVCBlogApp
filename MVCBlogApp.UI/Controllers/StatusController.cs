using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCBlogApp.Application.Features.Commands.Status.CreateStatus;
using MVCBlogApp.Application.Features.Queries.Status.GetAllStatus;

namespace MVCBlogApp.UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class StatusController : Controller
    {
        private readonly IMediator _mediator;

        public StatusController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index(GetAllStatusQueryRequest request)
        {
            GetAllStatusQueryResponse response = await _mediator.Send(request);
            return View(response.AllStatus);
        }

        [HttpGet]
        public IActionResult CreateStatus()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateStatus(CreateStatusCommandRequest request)
        {
            CreateStatusCommandResponse response = await _mediator.Send(request);
            if (response.Status)
            {
                return RedirectToAction("CreateStatus","Status");
            }
            else
            {
                return RedirectToAction("Index", "Status");
            }
        }

        [HttpGet]
        public IActionResult UpdateStatus()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UpdateStatus(int b)
        {
            return View();
        }

        public IActionResult DeleteStatus()
        {
            return View();
        }
    }
}
