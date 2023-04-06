using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCBlogApp.Application.Features.Commands.Fix.FixBmh.FixBmhCreate;
using MVCBlogApp.Application.Features.Commands.Fix.FixBmh.FixBmhDelete;
using MVCBlogApp.Application.Features.Commands.Fix.FixBmh.FixBmhUpdate;
using MVCBlogApp.Application.Features.Commands.Fix.FixBMI.FixBMICreate;
using MVCBlogApp.Application.Features.Commands.Fix.FixBMI.FixBMIDelete;
using MVCBlogApp.Application.Features.Commands.Fix.FixBMI.FixBMIUpdate;
using MVCBlogApp.Application.Features.Commands.Fix.FixCalorieSch.FixCalorieSchCreate;
using MVCBlogApp.Application.Features.Commands.Fix.FixCalorieSch.FixCalorieSchDelete;
using MVCBlogApp.Application.Features.Commands.Fix.FixCalorieSch.FixCalorieSchUpdate;
using MVCBlogApp.Application.Features.Commands.Fix.FixFeedPyramid.FixFeedPyramidCreate;
using MVCBlogApp.Application.Features.Commands.Fix.FixFeedPyramid.FixFeedPyramidDelete;
using MVCBlogApp.Application.Features.Commands.Fix.FixFeedPyramid.FixFeedPyramidUpdate;
using MVCBlogApp.Application.Features.Commands.Fix.FixHeartDiseases.FixHeartDiseasesCreate;
using MVCBlogApp.Application.Features.Commands.Fix.FixHeartDiseases.FixHeartDiseasesDelete;
using MVCBlogApp.Application.Features.Commands.Fix.FixHeartDiseases.FixHeartDiseasesUpdate;
using MVCBlogApp.Application.Features.Commands.Fix.FixMealSize.FixMealSizeCreate;
using MVCBlogApp.Application.Features.Commands.Fix.FixMealSize.FixMealSizeDelete;
using MVCBlogApp.Application.Features.Commands.Fix.FixMealSize.FixMealSizeUpdate;
using MVCBlogApp.Application.Features.Commands.Fix.FixOptimum.FixOptimumCreate;
using MVCBlogApp.Application.Features.Commands.Fix.FixOptimum.FixOptimumDelete;
using MVCBlogApp.Application.Features.Commands.Fix.FixOptimum.FixOptimumUpdate;
using MVCBlogApp.Application.Features.Commands.Fix.FixPulse.FixPulseCreate;
using MVCBlogApp.Application.Features.Queries.Fix.FixBmh.GetAllFixBmhs;
using MVCBlogApp.Application.Features.Queries.Fix.FixBmh.GetByIdFixBmh;
using MVCBlogApp.Application.Features.Queries.Fix.FixBmh.GetFixBmhCreateItems;
using MVCBlogApp.Application.Features.Queries.Fix.FixBMI.GetAllFixBMI;
using MVCBlogApp.Application.Features.Queries.Fix.FixBMI.GetByIdFixBMI;
using MVCBlogApp.Application.Features.Queries.Fix.FixBMI.GetFixBMICreateItems;
using MVCBlogApp.Application.Features.Queries.Fix.FixCalorieSch.GetAllFixCalorieSch;
using MVCBlogApp.Application.Features.Queries.Fix.FixCalorieSch.GetByIdFixCalorieSch;
using MVCBlogApp.Application.Features.Queries.Fix.FixCalorieSch.GetFixCalorieSchCreateItems;
using MVCBlogApp.Application.Features.Queries.Fix.FixFeedPyramid.GetAllFixFeedPyramid;
using MVCBlogApp.Application.Features.Queries.Fix.FixFeedPyramid.GetByIdFixFeedPyramid;
using MVCBlogApp.Application.Features.Queries.Fix.FixFeedPyramid.GetFixFeedPyramidCreateItems;
using MVCBlogApp.Application.Features.Queries.Fix.FixHeartDiseases.GetAllFixHeartDiseases;
using MVCBlogApp.Application.Features.Queries.Fix.FixHeartDiseases.GetByIdFixHeartDiseases;
using MVCBlogApp.Application.Features.Queries.Fix.FixHeartDiseases.GetFixHeartDiseasesCreateItems;
using MVCBlogApp.Application.Features.Queries.Fix.FixMealSize.GetAllFixMealSize;
using MVCBlogApp.Application.Features.Queries.Fix.FixMealSize.GetByIdFixMealSize;
using MVCBlogApp.Application.Features.Queries.Fix.FixMealSize.GetFixMealSizeCreateItems;
using MVCBlogApp.Application.Features.Queries.Fix.FixOptimum.GetAllFixOptimum;
using MVCBlogApp.Application.Features.Queries.Fix.FixOptimum.GetByIdFixOptimum;
using MVCBlogApp.Application.Features.Queries.Fix.FixOptimum.GetFixOptimumCreateItems;
using MVCBlogApp.Application.Features.Queries.Fix.FixPulse.GetAllFixPulse;
using MVCBlogApp.Application.Features.Queries.Fix.FixPulse.GetFixPulseCreateItems;

namespace MVCBlogApp.UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class FixController : Controller
    {
        private readonly IMediator _mediator;

        public FixController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region FixBmh

        [HttpGet]
        public async Task<IActionResult> FixBmhList(GetAllFixBmhsQueryRequest request)
        {
            GetAllFixBmhsQueryResponse response = await _mediator.Send(request);
            return View(response.FixBmhs);
        }

        [HttpGet]
        public async Task<IActionResult> FixBmhCreate(GetFixBmhCreateItemsQueryRequest request)
        {
            GetFixBmhCreateItemsQueryResponse response = await _mediator.Send(request);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> FixBmhCreate(FixBmhCreateCommandRequest request)
        {
            FixBmhCreateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("FixBmhList", "Fix");
            }
            else
            {
                return RedirectToAction("FixBmhCreate", "Fix");
            }
        }

        [HttpGet]
        public async Task<IActionResult> FixBmhUpdate(GetByIdFixBmhQueryRequest request)
        {
            GetByIdFixBmhQueryResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return View(response);
            }
            else
            {
                return RedirectToAction("FixBmhList", "Fix");
            }            
        }

        [HttpPost]
        public async Task<IActionResult> FixBmhUpdate(FixBmhUpdateCommandRequest request)
        {
            FixBmhUpdateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("FixBmhList", "Fix");
            }
            else
            {
                return RedirectToAction("FixBmhUpdate", "Fix");
            }
        }

        public async Task<IActionResult> FixBmhDelete(FixBmhDeleteCommandRequest request)
        {
            FixBmhDeleteCommandResponse response = await _mediator.Send(request);
            return RedirectToAction("FixBmhList", "Fix");
        }

        #endregion

        #region FixBMI

        [HttpGet]
        public async Task<IActionResult> FixBMIList(GetAllFixBMIQueryRequest request)
        {
            GetAllFixBMIQueryResponse response = await _mediator.Send(request);
            return View(response.FixBMIs);
        }

        [HttpGet]
        public async Task<IActionResult> FixBMICreate(GetFixBMICreateItemsQueryRequest request)
        {
            GetFixBMICreateItemsQueryResponse response = await _mediator.Send(request);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> FixBMICreate(FixBMICreateCommandRequest request)
        {
            FixBMICreateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("FixBMIList", "Fix");
            }
            else
            {
                return RedirectToAction("FixBMICreate", "Fix");
            }
        }

        [HttpGet]
        public async Task<IActionResult> FixBMIUpdate(GetByIdFixBMIQueryRequest request)
        {
            GetByIdFixBMIQueryResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return View(response);
            }
            else
            {
                return RedirectToAction("FixBMIList", "Fix");
            }
        }

        [HttpPost]
        public async Task<IActionResult> FixBMIUpdate(FixBMIUpdateCommandRequest request)
        {
            FixBMIUpdateCommandResponse response = await _mediator.Send(request);

            if (response.State)
            {
                return RedirectToAction("FixBMIList", "Fix");
            }
            else
            {
                return RedirectToAction("FixBMIUpdate", "Fix");
            }
        }

        public async Task<IActionResult> FixBMIDelete(FixBMIDeleteCommandRequest request)
        {
            FixBMIDeleteCommandResponse response = await _mediator.Send(request);
            return RedirectToAction("FixBMIList", "Fix");
        }

        #endregion

        #region FixCalorieSch

        [HttpGet]
        public async Task<IActionResult> FixCalorieSchList(GetAllFixCalorieSchQueryRequest request)
        {
            GetAllFixCalorieSchQueryResponse response = await _mediator.Send(request);
            return View(response.FixCalorieSches);
        }

        [HttpGet]
        public async Task<IActionResult> FixCalorieSchCreate(GetFixCalorieSchCreateItemsQueryRequest request)
        {
            GetFixCalorieSchCreateItemsQueryResponse response = await _mediator.Send(request);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> FixCalorieSchCreate(FixCalorieSchCreateCommandRequest request)
        {
            FixCalorieSchCreateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("FixCalorieSchList", "Fix");
            }
            else
            {
                return RedirectToAction("FixCalorieSchCreate", "Fix");
            }
        }

        [HttpGet]
        public async Task<IActionResult> FixCalorieSchUpdate(GetByIdFixCalorieSchQueryRequest request)
        {
            GetByIdFixCalorieSchQueryResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return View(response);
            }
            else
            {
                return RedirectToAction("FixCalorieSchList", "Fix");
            }
        }

        [HttpPost]
        public async Task<IActionResult> FixCalorieSchUpdate(FixCalorieSchUpdateCommandRequest request)
        {
            FixCalorieSchUpdateCommandResponse response = await _mediator.Send(request);

            if (response.State)
            {
                return RedirectToAction("FixCalorieSchList", "Fix");
            }
            else
            {
                return RedirectToAction("FixCalorieSchUpdate", "Fix");
            }
        }

        public async Task<IActionResult> FixCalorieSchDelete(FixCalorieSchDeleteCommandRequest request)
        {
            FixCalorieSchDeleteCommandResponse response = await _mediator.Send(request);
            return RedirectToAction("FixCalorieSchList", "Fix");
        }

        #endregion

        #region FixFeedPyramid

        [HttpGet]
        public async Task<IActionResult> FixFeedPyramidList(GetAllFixFeedPyramidQueryRequest request)
        {
            GetAllFixFeedPyramidQueryResponse response = await _mediator.Send(request);
            return View(response.FixFeedPyramids);
        }

        [HttpGet]
        public async Task<IActionResult> FixFeedPyramidCreate(GetFixFeedPyramidCreateItemsQueryRequest request)
        {
            GetFixFeedPyramidCreateItemsQueryResponse response = await _mediator.Send(request);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> FixFeedPyramidCreate(FixFeedPyramidCreateCommandRequest request)
        {
            FixFeedPyramidCreateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("FixFeedPyramidList", "Fix");
            }
            else
            {
                return RedirectToAction("FixFeedPyramidCreate", "Fix");
            }
        }

        [HttpGet]
        public async Task<IActionResult> FixFeedPyramidUpdate(GetByIdFixFeedPyramidQueryRequest request)
        {
            GetByIdFixFeedPyramidQueryResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return View(response);
            }
            else
            {
                return RedirectToAction("FixFeedPyramidList", "Fix");
            }
        }

        [HttpPost]
        public async Task<IActionResult> FixFeedPyramidUpdate(FixFeedPyramidUpdateCommandRequest request)
        {
            FixFeedPyramidUpdateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("FixFeedPyramidList", "Fix");
            }
            else
            {
                return RedirectToAction("FixFeedPyramidUpdate", "Fix");
            }
        }

        public async Task<IActionResult> FixFeedPyramidDelete(FixFeedPyramidDeleteCommandRequest request)
        {
            FixFeedPyramidDeleteCommandResponse response = await _mediator.Send(request);
            return RedirectToAction("FixFeedPyramidList", "Fix");
        }

        #endregion

        #region FixHeartDiseases

        [HttpGet]
        public async Task<IActionResult> FixHeartDiseasesList(GetAllFixHeartDiseasesQueryRequest request)
        {
            GetAllFixHeartDiseasesQueryResponse response = await _mediator.Send(request);
            return View(response.FixHeartDiseases);
        }

        [HttpGet]
        public async Task<IActionResult> FixHeartDiseasesCreate(GetFixHeartDiseasesCreateItemsQueryRequest request)
        {
            GetFixHeartDiseasesCreateItemsQueryResponse response = await _mediator.Send(request);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> FixHeartDiseasesCreate(FixHeartDiseasesCreateCommandRequest request)
        {
            FixHeartDiseasesCreateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("FixHeartDiseasesList", "Fix");
            }
            else
            {
                return RedirectToAction("FixHeartDiseasesCreate", "Fix");
            }
        }

        [HttpGet]
        public async Task<IActionResult> FixHeartDiseasesUpdate(GetByIdFixHeartDiseasesQueryRequest request)
        {
            GetByIdFixHeartDiseasesQueryResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return View(response);
            }
            else
            {
                return RedirectToAction("FixFeedPyramidList", "Fix");
            }
        }

        [HttpPost]
        public async Task<IActionResult> FixHeartDiseasesUpdate(FixHeartDiseasesUpdateCommandRequest request)
        {
            FixHeartDiseasesUpdateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("FixFeedPyramidList", "Fix");
            }
            else
            {
                return RedirectToAction("FixHeartDiseasesUpdate", "Fix");
            }
        }

        public async Task<IActionResult> FixHeartDiseasesDelete(FixHeartDiseasesDeleteCommandRequest request)
        {
            FixHeartDiseasesDeleteCommandResponse response = await _mediator.Send(request);
            return RedirectToAction("FixFeedPyramidList", "Fix");
        }

        #endregion

        #region FixMealSize

        [HttpGet]
        public async Task<IActionResult> FixMealSizeList(GetAllFixMealSizeQueryRequest request)
        {
            GetAllFixMealSizeQueryResponse response = await _mediator.Send(request);
            return View(response.FixMealSizes);
        }

        [HttpGet]
        public async Task<IActionResult> FixMealSizeCreate(GetFixMealSizeCreateItemsQueryRequest request)
        {
            GetFixMealSizeCreateItemsQueryResponse response = await _mediator.Send(request);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> FixMealSizeCreate(FixMealSizeCreateCommandRequest request)
        {
            FixMealSizeCreateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("FixMealSizeList", "Fix");
            }
            else
            {
                return RedirectToAction("FixMealSizeCreate", "Fix");
            }
        }

        [HttpGet]
        public async Task<IActionResult> FixMealSizeUpdate(GetByIdFixMealSizeQueryRequest request)
        {
            GetByIdFixMealSizeQueryResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return View(response);
            }
            else
            {
                return RedirectToAction("FixMealSizeList", "Fix");
            }
        }

        [HttpPost]
        public async Task<IActionResult> FixMealSizeUpdate(FixMealSizeUpdateCommandRequest request)
        {
            FixMealSizeUpdateCommandResponse response = await _mediator.Send(request);

            if (response.State)
            {
                return RedirectToAction("FixMealSizeList", "Fix");
            }
            else
            {
                return RedirectToAction("FixMealSizeUpdate", "Fix");
            }
        }

        public async Task<IActionResult> FixMealSizeDelete(FixMealSizeDeleteCommandRequest request)
        {
            FixMealSizeDeleteCommandResponse response = await _mediator.Send(request);
            return RedirectToAction("FixMealSizeList", "Fix");
        }

        #endregion

        #region FixOptimum

        [HttpGet]
        public async Task<IActionResult> FixOptimumList(GetAllFixOptimumQueryRequest request)
        {
            GetAllFixOptimumQueryResponse response = await _mediator.Send(request);
            return View(response.FixOptimums);
        }

        [HttpGet]
        public async Task<IActionResult> FixOptimumCreate(GetFixOptimumCreateItemsQueryRequest request)
        {
            GetFixOptimumCreateItemsQueryResponse response = await _mediator.Send(request);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> FixOptimumCreate(FixOptimumCreateCommandRequest request)
        {
            FixOptimumCreateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("FixOptimumList", "Fix");
            }
            else
            {
                return RedirectToAction("FixOptimumCreate", "Fix");
            }
        }

        [HttpGet]
        public async Task<IActionResult> FixOptimumUpdate(GetByIdFixOptimumQueryRequest request)
        {
            GetByIdFixOptimumQueryResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return View(response);
            }
            else
            {
                return RedirectToAction("FixOptimumList", "Fix");
            }
        }

        [HttpPost]
        public async Task<IActionResult> FixOptimumUpdate(FixOptimumUpdateCommandRequest request)
        {
            FixOptimumUpdateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("FixOptimumList", "Fix");
            }
            else
            {
                return RedirectToAction("FixOptimumUpdate", "Fix");
            }
        }

        public async Task<IActionResult> FixOptimumDelete(FixOptimumDeleteCommandRequest request)
        {
            FixOptimumDeleteCommandResponse response = await _mediator.Send(request);
            return RedirectToAction("FixOptimumList", "Fix");
        }

        #endregion

        #region FixPulse

        [HttpGet]
        public async Task<IActionResult> FixPulseList(GetAllFixPulseQueryRequest request)
        {
            GetAllFixPulseQueryResponse response = await _mediator.Send(request);
            return View(response.FixPulses);
        }

        [HttpGet]
        public async Task<IActionResult> FixPulseCreate(GetFixPulseCreateItemsQueryRequest request)
        {
            GetFixPulseCreateItemsQueryResponse response = await _mediator.Send(request);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> FixPulseCreate(FixPulseCreateCommandRequest request)
        {
            FixPulseCreateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("FixPulseList", "Fix");
            }
            else
            {
                return RedirectToAction("FixPulseCreate", "Fix");
            }
        }

        [HttpGet]
        public async Task<IActionResult> FixPulseUpdate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> FixPulseUpdate(int a)
        {
            return View();
        }

        public async Task<IActionResult> FixPulseDelete(int a)
        {
            return View();
        }

        #endregion
    }
}
