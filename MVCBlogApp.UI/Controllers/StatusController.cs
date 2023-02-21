using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCBlogApp.Application.Features.Commands.Status.CreateStatus;
using MVCBlogApp.Application.Features.Commands.Status.DeleteStatus;
using MVCBlogApp.Application.Features.Commands.Status.UpdateStatus;
using MVCBlogApp.Application.Features.Queries.Status.GetAllStatus;
using MVCBlogApp.Application.Features.Queries.Status.GetByIdStatus;

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
        public async Task<IActionResult> UpdateStatus(GetByIdStatusQueryRequest request)
        {
            GetByIdStatusQueryResponse response = await _mediator.Send(request);

            if (response.State)
            {
                return View(response.Status);
            }
            else
            {
                return RedirectToAction("Index", "Status");
            }            
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStatus(UpdateStatusCommandRequest request)
        {
            UpdateStatusCommandResponse response = await _mediator.Send(request);

            if (response.Status)
            {
                return RedirectToAction("Index", "Status");
            }
            else
            {
                return RedirectToAction("UpdateStatus", "Status");
            }            
        }

        public async Task<IActionResult> DeleteStatus(DeleteStatusCommandRequest request)
        {
            DeleteStatusCommandResponse response = await _mediator.Send(request);
            return RedirectToAction("Index", "Status");
        }
    }
}
