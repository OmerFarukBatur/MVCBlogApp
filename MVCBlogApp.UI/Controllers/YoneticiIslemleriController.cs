using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Features.Commands.YoneticiIslemleri.AdminByIdRemove;
using MVCBlogApp.Application.Features.Commands.YoneticiIslemleri.AdminCreate;
using MVCBlogApp.Application.Features.Commands.YoneticiIslemleri.AdminUpdate;
using MVCBlogApp.Application.Features.Commands.YoneticiIslemleri.TK.TKBiographyCreate;
using MVCBlogApp.Application.Features.Commands.YoneticiIslemleri.TK.TKBiographyDelete;
using MVCBlogApp.Application.Features.Commands.YoneticiIslemleri.TK.TKBiographyUpdate;
using MVCBlogApp.Application.Features.Queries.YoneticiIslemleri.AdminRoleList;
using MVCBlogApp.Application.Features.Queries.YoneticiIslemleri.AllAdmin;
using MVCBlogApp.Application.Features.Queries.YoneticiIslemleri.GetByIdAdmin;
using MVCBlogApp.Application.Features.Queries.YoneticiIslemleri.TK.GetAllTKBiography;
using MVCBlogApp.Application.Features.Queries.YoneticiIslemleri.TK.GetByIdTKBiography;
using MVCBlogApp.Application.Features.Queries.YoneticiIslemleri.TK.GetTKBiographyCreateItems;
using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class YoneticiIslemleriController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IOperationService _operationService;

        public YoneticiIslemleriController(IMediator mediator, IOperationService operationService)
        {
            _mediator = mediator;
            _operationService = operationService;
        }

        #region Admin

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
            SessionUser user = _operationService.GetUser();
            request.CreateUserID = user.Id;
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
            if (response.State)
            {
                return View(response);
            }
            else
            {
                return RedirectToAction("AdminList", "YoneticiIslemleri");
            }
            
        }
        [HttpPost]
        public async Task<IActionResult> AdminUpdate(AdminUpdateCommandRequest request)
        {
            SessionUser user = _operationService.GetUser();
            request.ModifiedUserID = user.Id;
            AdminUpdateCommandResponse response = await _mediator.Send(request);

            if (response.Status)
            {
                return RedirectToAction("AdminList", "YoneticiIslemleri");
            }
            else
            {
                return RedirectToAction("AdminUpdate", "YoneticiIslemleri",request.Id);
            }            
        }
        
        public async Task<IActionResult> AdminDelete(AdminByIdRemoveCommandRequest request)
        {
            AdminByIdRemoveCommandResponse response = await _mediator.Send(request);
            return RedirectToAction("AdminList", "YoneticiIslemleri");
        }

        #endregion

        #region TK

        public async Task<IActionResult> TKBiographyList(GetAllTKBiographyQueryRequest request)
        {
            GetAllTKBiographyQueryResponse response = await _mediator.Send(request);
            return View(response.TaylanKs);
        }

        [HttpGet]
        public async Task<IActionResult> TKBiographyCreate(GetTKBiographyCreateItemsQueryRequest request)
        {
            GetTKBiographyCreateItemsQueryResponse response = await _mediator.Send(request);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> TKBiographyCreate(TKBiographyCreateCommandRequest request)
        {
            request.UserId = _operationService.GetUser().Id;
            TKBiographyCreateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("TKBiographyList", "YoneticiIslemleri");
            }
            else
            {
                return RedirectToAction("TKBiographyCreate", "YoneticiIslemleri");
            }
        }

        [HttpGet]
        public async Task<IActionResult> TKBiographyUpdate(GetByIdTKBiographyQueryRequest request)
        {
            GetByIdTKBiographyQueryResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return View(response);
            }
            else
            {
                return RedirectToAction("TKBiographyUpdate", "YoneticiIslemleri");
            }
        }

        [HttpPost]
        public async Task<IActionResult> TKBiographyUpdate(TKBiographyUpdateCommandRequest request)
        {
            TKBiographyUpdateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("TKBiographyList", "YoneticiIslemleri");
            }
            else
            {
                return RedirectToAction("TKBiographyUpdate", "YoneticiIslemleri");
            }
        }


        public async Task<IActionResult> TKBiographyDelete(TKBiographyDeleteCommandRequest request)
        {
            TKBiographyDeleteCommandResponse response = await _mediator.Send(request);
            return RedirectToAction("TKBiographyList", "YoneticiIslemleri");
        }

        #endregion
    }
}
