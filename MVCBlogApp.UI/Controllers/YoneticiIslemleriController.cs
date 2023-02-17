using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCBlogApp.Application.Features.Commands.YoneticiIslemleri.AdminCreate;
using MVCBlogApp.Application.Features.Queries.YoneticiIslemleri.AdminRoleList;
using MVCBlogApp.Application.Features.Queries.YoneticiIslemleri.AllAdmin;

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
        public IActionResult AdminUpdate()
        {
            return View();
        }
        public IActionResult AdminDelete()
        {
            return View();
        }
        public IActionResult AdminRoleList()
        {
            return View();
        }

    }
}
