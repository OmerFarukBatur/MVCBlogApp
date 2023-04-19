using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Features.Commands.Workshop.Workshop.WorkshopCreate;
using MVCBlogApp.Application.Features.Commands.Workshop.WorkshopCategory.WorkshopCategoryCreate;
using MVCBlogApp.Application.Features.Commands.Workshop.WorkshopCategory.WorkshopCategoryDelete;
using MVCBlogApp.Application.Features.Commands.Workshop.WorkshopCategory.WorkshopCategoryUpdate;
using MVCBlogApp.Application.Features.Commands.Workshop.WorkshopEducation.WorkshopEducationCreate;
using MVCBlogApp.Application.Features.Commands.Workshop.WorkshopEducation.WorkshopEducationDelete;
using MVCBlogApp.Application.Features.Commands.Workshop.WorkshopEducation.WorkshopEducationUpdate;
using MVCBlogApp.Application.Features.Commands.Workshop.WorkshopType.WorkshopTypeCreate;
using MVCBlogApp.Application.Features.Commands.Workshop.WorkshopType.WorkshopTypeDelete;
using MVCBlogApp.Application.Features.Commands.Workshop.WorkshopType.WorkshopTypeUpdate;
using MVCBlogApp.Application.Features.Queries.Workshop.Workshop.GetAllWorkshop;
using MVCBlogApp.Application.Features.Queries.Workshop.Workshop.GetByIdWorkshop;
using MVCBlogApp.Application.Features.Queries.Workshop.Workshop.GetWorkshopCreateItems;
using MVCBlogApp.Application.Features.Queries.Workshop.WorkshopCategory.GetAllWorkshopCategory;
using MVCBlogApp.Application.Features.Queries.Workshop.WorkshopCategory.GetByIdWorkshopCategory;
using MVCBlogApp.Application.Features.Queries.Workshop.WorkshopCategory.GetWorkshopCategoryCreateItems;
using MVCBlogApp.Application.Features.Queries.Workshop.WorkshopEducation.GetAllWorkshopEducation;
using MVCBlogApp.Application.Features.Queries.Workshop.WorkshopEducation.GetByIdWorkshopEducation;
using MVCBlogApp.Application.Features.Queries.Workshop.WorkshopEducation.GetWorkshopEducationCreateItems;
using MVCBlogApp.Application.Features.Queries.Workshop.WorkshopType.GetAllWorkshopType;
using MVCBlogApp.Application.Features.Queries.Workshop.WorkshopType.GetByIdWorkshopType;
using MVCBlogApp.Application.Features.Queries.Workshop.WorkshopType.GetWorkshopTypeCreateItems;

namespace MVCBlogApp.UI.Controllers
{
    [Authorize(Roles ="Admin")]
    public class WorkshopController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IOperationService _operationService;

        public WorkshopController(IMediator mediator, IOperationService operationService)
        {
            _mediator = mediator;
            _operationService = operationService;
        }

        #region Workshop

        [HttpGet]
        public async Task<IActionResult> WorkshopList(GetAllWorkshopQueryRequest request)
        {
            GetAllWorkshopQueryResponse response = await _mediator.Send(request);
            return View(response.Workshops);
        }

        [HttpGet]
        public async Task<IActionResult> WorkshopCreate(GetWorkshopCreateItemsQueryRequest request)
        {
            GetWorkshopCreateItemsQueryResponse response = await _mediator.Send(request);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> WorkshopCreate(WorkshopCreateCommandRequest request)
        {
            request.CreateUserId = _operationService.GetUser().Id;
            WorkshopCreateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("WorkshopList", "Workshop");
            }
            else
            {
                return RedirectToAction("WorkshopCreate", "Workshop");
            }
        }

        [HttpGet]
        public async Task<IActionResult> WorkshopUpdate(GetByIdWorkshopQueryRequest request)
        {
            GetByIdWorkshopQueryResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return View(response);
            }
            else
            {
                return RedirectToAction("WorkshopList", "Workshop");
            }
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

        #region WorkshopCategory

        [HttpGet]
        public async Task<IActionResult> WorkshopCategoryList(GetAllWorkshopCategoryQueryRequest request)
        {
            GetAllWorkshopCategoryQueryResponse response = await _mediator.Send(request);
            return View(response.WorkshopCategories);
        }

        [HttpGet]
        public async Task<IActionResult> WorkshopCategoryCreate(GetWorkshopCategoryCreateItemsQueryRequest request)
        {
            GetWorkshopCategoryCreateItemsQueryResponse response = await _mediator.Send(request);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> WorkshopCategoryCreate(WorkshopCategoryCreateCommandRequest request)
        {
            WorkshopCategoryCreateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("WorkshopCategoryList", "Workshop");
            }
            else
            {
                return RedirectToAction("WorkshopCategoryCreate", "Workshop");
            }
        }

        [HttpGet]
        public async Task<IActionResult> WorkshopCategoryUpdate(GetByIdWorkshopCategoryQueryRequest request)
        {
            GetByIdWorkshopCategoryQueryResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return View(response);
            }
            else
            {
                return RedirectToAction("WorkshopCategoryList", "Workshop");
            }
        }

        [HttpPost]
        public async Task<IActionResult> WorkshopCategoryUpdate(WorkshopCategoryUpdateCommandRequest request)
        {
            WorkshopCategoryUpdateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("WorkshopCategoryList", "Workshop");
            }
            else
            {
                return RedirectToAction("WorkshopCategoryUpdate", "Workshop");
            }
        }

        public async Task<IActionResult> WorkshopCategoryDelete(WorkshopCategoryDeleteCommandRequest request)
        {
            WorkshopCategoryDeleteCommandResponse response = await _mediator.Send(request);
            return RedirectToAction("WorkshopCategoryList", "Workshop");
        }

        #endregion

        #region WorkshopEducation

        [HttpGet]
        public async Task<IActionResult> WorkshopEducationList(GetAllWorkshopEducationQueryRequest request)
        {
            GetAllWorkshopEducationQueryResponse response = await _mediator.Send(request);
            return View(response.WorkshopEducations);
        }

        [HttpGet]
        public async Task<IActionResult> WorkshopEducationCreate(GetWorkshopEducationCreateItemsQueryRequest request)
        {
            GetWorkshopEducationCreateItemsQueryResponse response = await _mediator.Send(request);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> WorkshopEducationCreate(WorkshopEducationCreateCommandRequest request)
        {
            WorkshopEducationCreateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("WorkshopEducationList", "Workshop");
            }
            else
            {
                return RedirectToAction("WorkshopEducationCreate", "Workshop");
            }
        }

        [HttpGet]
        public async Task<IActionResult> WorkshopEducationUpdate(GetByIdWorkshopEducationQueryRequest request)
        {
            GetByIdWorkshopEducationQueryResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return View(response);
            }
            else
            {
                return RedirectToAction("WorkshopEducationList", "Workshop");
            }
        }

        [HttpPost]
        public async Task<IActionResult> WorkshopEducationUpdate(WorkshopEducationUpdateCommandRequest request)
        {
            WorkshopEducationUpdateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("WorkshopEducationList", "Workshop");
            }
            else
            {
                return RedirectToAction("WorkshopEducationUpdate", "Workshop");
            }
        }

        public async Task<IActionResult> WorkshopEducationDelete(WorkshopEducationDeleteCommandRequest request)
        {
            WorkshopEducationDeleteCommandResponse response = await _mediator.Send(request);
            return RedirectToAction("WorkshopEducationList", "Workshop");
        }

        #endregion

        #region WorkshopType

        [HttpGet]
        public async Task<IActionResult> WorkshopTypeList(GetAllWorkshopTypeQueryRequest request)
        {
            GetAllWorkshopTypeQueryResponse response = await _mediator.Send(request);
            return View(response.WorkshopTypes);
        }

        [HttpGet]
        public async Task<IActionResult> WorkshopTypeCreate(GetWorkshopTypeCreateItemsQueryRequest request)
        {
            GetWorkshopTypeCreateItemsQueryResponse response = await _mediator.Send(request);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> WorkshopTypeCreate(WorkshopTypeCreateCommandRequest request)
        {
            WorkshopTypeCreateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("WorkshopTypeList", "Workshop");
            }
            else
            {
                return RedirectToAction("WorkshopTypeCreate", "Workshop");
            }
        }

        [HttpGet]
        public async Task<IActionResult> WorkshopTypeUpdate(GetByIdWorkshopTypeQueryRequest request)
        {
            GetByIdWorkshopTypeQueryResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return View(response);
            }
            else
            {
                return RedirectToAction("WorkshopTypeList", "Workshop");
            }            
        }

        [HttpPost]
        public async Task<IActionResult> WorkshopTypeUpdate(WorkshopTypeUpdateCommandRequest request)
        {
            WorkshopTypeUpdateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("WorkshopTypeList", "Workshop");
            }
            else
            {
                return RedirectToAction("WorkshopTypeUpdate", "Workshop");
            }
        }

        public async Task<IActionResult> WorkshopTypeDelete(WorkshopTypeDeleteCommandRequest request)
        {
            WorkshopTypeDeleteCommandResponse response = await _mediator.Send(request);
            return RedirectToAction("WorkshopTypeList", "Workshop");
        }

        #endregion
    }
}
