using MediatR;
using Microsoft.AspNetCore.Mvc;
using MVCBlogApp.Application.Features.Commands.YoneticiIslemleri.AdminCreate;
using MVCBlogApp.Application.Features.Queries.YoneticiIslemleri.AdminRoleList;

namespace MVCBlogApp.UI.Controllers
{
    public class YoneticiIslemleriController : Controller
    {
        private readonly IMediator _mediator;

        public YoneticiIslemleriController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IActionResult AdminList()
        {
            return View();
        }
        public async Task<IActionResult> AdminCreate(AdminRoleListQueryRequest request)
        {
            AdminRoleListQueryResponse response = await _mediator.Send(request);
            return View(response);
        }
        public async Task<IActionResult> AdminCreate(AdminCreateCommandRequest request)
        {
            AdminCreateCommandResponse response = await _mediator.Send(request);
            if (response.Status)
            {
                return RedirectToAction("AdminList", "YoneticiIslemleri",response.Message);
            }
            else
            {
                return RedirectToAction("AdminCreate", "YoneticiIslemleri",response.Message);
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
