﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCBlogApp.Application.Features.Commands.Fix.FixBmh.FixBmhCreate;
using MVCBlogApp.Application.Features.Commands.Fix.FixBmh.FixBmhDelete;
using MVCBlogApp.Application.Features.Commands.Fix.FixBmh.FixBmhUpdate;
using MVCBlogApp.Application.Features.Commands.Fix.FixBMI.FixBMICreate;
using MVCBlogApp.Application.Features.Queries.Fix.FixBmh.GetAllFixBmhs;
using MVCBlogApp.Application.Features.Queries.Fix.FixBmh.GetByIdFixBmh;
using MVCBlogApp.Application.Features.Queries.Fix.FixBmh.GetFixBmhCreateItems;
using MVCBlogApp.Application.Features.Queries.Fix.FixBMI.GetAllFixBMI;
using MVCBlogApp.Application.Features.Queries.Fix.FixBMI.GetByIdFixBMI;
using MVCBlogApp.Application.Features.Queries.Fix.FixBMI.GetFixBMICreateItems;

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
        public async Task<IActionResult> FixBMIUpdate(int a)
        {
            return View();
        }

        public async Task<IActionResult> FixBMIDelete(int a)
        {
            return View();
        }

        #endregion

        #region FixCalorieSch

        [HttpGet]
        public async Task<IActionResult> FixCalorieSchList()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> FixCalorieSchCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> FixCalorieSchCreate(int a)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> FixCalorieSchUpdate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> FixCalorieSchUpdate(int a)
        {
            return View();
        }

        public async Task<IActionResult> FixCalorieSchDelete(int a)
        {
            return View();
        }

        #endregion

        #region FixFeedPyramid

        [HttpGet]
        public async Task<IActionResult> FixFeedPyramidList()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> FixFeedPyramidCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> FixFeedPyramidCreate(int a)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> FixFeedPyramidUpdate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> FixFeedPyramidUpdate(int a)
        {
            return View();
        }

        public async Task<IActionResult> FixFeedPyramidDelete(int a)
        {
            return View();
        }

        #endregion

        #region FixHeartDiseases

        [HttpGet]
        public async Task<IActionResult> FixHeartDiseasesList()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> FixHeartDiseasesCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> FixHeartDiseasesCreate(int a)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> FixHeartDiseasesUpdate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> FixHeartDiseasesUpdate(int a)
        {
            return View();
        }

        public async Task<IActionResult> FixHeartDiseasesDelete(int a)
        {
            return View();
        }

        #endregion

        #region FixMealSize

        [HttpGet]
        public async Task<IActionResult> FixMealSizeList()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> FixMealSizeCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> FixMealSizeCreate(int a)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> FixMealSizeUpdate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> FixMealSizeUpdate(int a)
        {
            return View();
        }

        public async Task<IActionResult> FixMealSizeDelete(int a)
        {
            return View();
        }

        #endregion

        #region FixOptimum

        [HttpGet]
        public async Task<IActionResult> FixOptimumList()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> FixOptimumCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> FixOptimumCreate(int a)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> FixOptimumUpdate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> FixOptimumUpdate(int a)
        {
            return View();
        }

        public async Task<IActionResult> FixOptimumDelete(int a)
        {
            return View();
        }

        #endregion

        #region FixPulse

        [HttpGet]
        public async Task<IActionResult> FixPulseList()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> FixPulseCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> FixPulseCreate(int a)
        {
            return View();
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
