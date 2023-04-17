using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCBlogApp.Application.Features.Commands.Workshop.WorkshopCategory.WorkshopCategoryCreate;
using MVCBlogApp.Application.Features.Commands.Workshop.WorkshopCategory.WorkshopCategoryDelete;
using MVCBlogApp.Application.Features.Commands.Workshop.WorkshopCategory.WorkshopCategoryUpdate;
using MVCBlogApp.Application.Features.Commands.Workshop.WorkshopType.WorkshopTypeCreate;
using MVCBlogApp.Application.Features.Commands.Workshop.WorkshopType.WorkshopTypeDelete;
using MVCBlogApp.Application.Features.Commands.Workshop.WorkshopType.WorkshopTypeUpdate;
using MVCBlogApp.Application.Features.Queries.Workshop.WorkshopCategory.GetAllWorkshopCategory;
using MVCBlogApp.Application.Features.Queries.Workshop.WorkshopCategory.GetByIdWorkshopCategory;
using MVCBlogApp.Application.Features.Queries.Workshop.WorkshopCategory.GetWorkshopCategoryCreateItems;
using MVCBlogApp.Application.Features.Queries.Workshop.WorkshopType.GetAllWorkshopType;
using MVCBlogApp.Application.Features.Queries.Workshop.WorkshopType.GetByIdWorkshopType;
using MVCBlogApp.Application.Features.Queries.Workshop.WorkshopType.GetWorkshopTypeCreateItems;

namespace MVCBlogApp.UI.Controllers
{
    [Authorize(Roles ="Admin")]
    public class WorkshopController : Controller
    {
        private readonly IMediator _mediator;

        public WorkshopController(IMediator mediator)
        {
            _mediator = mediator;
        }

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
        public async Task<IActionResult> WorkshopEducationList()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> WorkshopEducationCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> WorkshopEducationCreate(int a)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> WorkshopEducationUpdate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> WorkshopEducationUpdate(int a)
        {
            return View();
        }

        public async Task<IActionResult> WorkshopEducationDelete(int a)
        {
            return View();
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
