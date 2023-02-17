using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCBlogApp.Application.Features.Commands.YoneticiIslemleri.AdminCreate;
using MVCBlogApp.Application.Features.Commands.YoneticiIslemleri.AdminUpdate;
using MVCBlogApp.Application.Features.Queries.YoneticiIslemleri.AdminRoleList;
using MVCBlogApp.Application.Features.Queries.YoneticiIslemleri.AllAdmin;
using MVCBlogApp.Application.Features.Queries.YoneticiIslemleri.GetByIdAdmin;

namespace MVCBlogApp.UI.Controllers
{
    [Authorize]
    public class YoneticiIslemleriController : Controller
    {
        private readonly IMediator _mediator;

        public YoneticiIslemleriController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> AdminList(AllAdminQueryRequest allAdminQueryRequest)
        {
            AllAdminQueryResponse response = await _mediator.Send(allAdminQueryRequest);
            return View(response.AllAdmins);
        }
        [HttpGet]
        public async Task<IActionResult> AdminCreate(AdminRoleListQueryRequest request)
        {
            AdminRoleListQueryResponse response = await _mediator.Send(request);
            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> AdminCreate(AdminCreateCommandRequest request)
        {
            AdminCreateCommandResponse response = await _mediator.Send(request);
            if (response.Status)
            {
                return RedirectToAction("AdminList", "YoneticiIslemleri");
            }
            else
            {
                return RedirectToAction("AdminCreate", "YoneticiIslemleri");
            }
        }
        [HttpGet]
        public async Task<IActionResult> AdminUpdate(GetByIdAdminQueryRequest request)
        {
            GetByIdAdminQueryResponse response = await _mediator.Send(request);
            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> AdminUpdate(AdminUpdateCommandRequest request)
        {
            AdminUpdateCommandResponse response = await _mediator.Send(request);
            return View(response);
        }
        public IActionResult AdminDelete(int id)
        {
            return View();
        }
        public IActionResult AdminRoleList()
        {
            return View();
        }

    }
}
