using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCBlogApp.Application.Features.Commands.Result.ResultBMhs.ResultBMhsCreate;
using MVCBlogApp.Application.Features.Commands.Result.ResultBMhs.ResultBMhsDelete;
using MVCBlogApp.Application.Features.Commands.Result.ResultBMhs.ResultBMhsUpdate;
using MVCBlogApp.Application.Features.Commands.Result.ResultBMIs.ResultBMIsCreate;
using MVCBlogApp.Application.Features.Commands.Result.ResultBMIs.ResultBMIsDelete;
using MVCBlogApp.Application.Features.Commands.Result.ResultBMIs.ResultBMIsUpdate;
using MVCBlogApp.Application.Features.Commands.Result.ResultOptimums.ResultOptimumsCreate;
using MVCBlogApp.Application.Features.Commands.Result.ResultOptimums.ResultOptimumsDelete;
using MVCBlogApp.Application.Features.Commands.Result.ResultOptimums.ResultOptimumsUpdate;
using MVCBlogApp.Application.Features.Commands.Result.ResultPulses.ResultPulsesCreate;
using MVCBlogApp.Application.Features.Commands.Result.ResultPulses.ResultPulsesDelete;
using MVCBlogApp.Application.Features.Commands.Result.ResultPulses.ResultPulsesUpdate;
using MVCBlogApp.Application.Features.Queries.Result.ResultBMhs.GetAllResultBMhs;
using MVCBlogApp.Application.Features.Queries.Result.ResultBMhs.GetByIdResultBMhs;
using MVCBlogApp.Application.Features.Queries.Result.ResultBMIs.GetAllResultBMI;
using MVCBlogApp.Application.Features.Queries.Result.ResultBMIs.GetByIdResultBMI;
using MVCBlogApp.Application.Features.Queries.Result.ResultOptimums.GetAllResultOptimums;
using MVCBlogApp.Application.Features.Queries.Result.ResultOptimums.GetByIdResultOptimum;
using MVCBlogApp.Application.Features.Queries.Result.ResultPulses.GetAllResultPulse;
using MVCBlogApp.Application.Features.Queries.Result.ResultPulses.GetByIdResultPulse;

namespace MVCBlogApp.UI.Controllers
{
    [Authorize(Roles ="Admin")]
    public class ResultController : Controller
    {
        private readonly IMediator _mediator;

        public ResultController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region ResultBMhs

        [HttpGet]
        public async Task<IActionResult> ResultBMhsList(GetAllResultBMhsQueryRequest request)
        {
            GetAllResultBMhsQueryResponse response = await _mediator.Send(request);
            return View(response.ResultBMhs);
        }

        [HttpGet]
        public IActionResult ResultBMhsCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResultBMhsCreate(ResultBMhsCreateCommandRequest request)
        {
            ResultBMhsCreateCommandResponse response = await _mediator.Send(request);

            if (response.State)
            {
                return RedirectToAction("ResultBMhsList", "Result");
            }
            else
            {
                return RedirectToAction("ResultBMhsCreate", "Result");
            }
        }

        [HttpGet]
        public async Task<IActionResult> ResultBMhsUpdate(GetByIdResultBMhsQueryRequest request)
        {
            GetByIdResultBMhsQueryResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return View(response.ResultBMhs);
            }
            else
            {
                return RedirectToAction("ResultBMhsList", "Result");
            }
        }

        [HttpPost]
        public async Task<IActionResult> ResultBMhsUpdate(ResultBMhsUpdateCommandRequest request)
        {
            ResultBMhsUpdateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("ResultBMhsList", "Result");
            }
            else
            {
                return RedirectToAction("ResultBMhsUpdate", "Result");
            }
        }

        public async Task<IActionResult> ResultBMhsDelete(ResultBMhsDeleteCommandRequest request)
        {
            ResultBMhsDeleteCommandResponse response = await _mediator.Send(request);
            return RedirectToAction("ResultBMhsList", "Result");
        }

        #endregion

        #region ResultBMIs

        [HttpGet]
        public async Task<IActionResult> ResultBMIsList(GetAllResultBMIQueryRequest request)
        {
            GetAllResultBMIQueryResponse response = await _mediator.Send(request);
            return View(response.ResultBMIs);
        }

        [HttpGet]
        public IActionResult ResultBMIsCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResultBMIsCreate(ResultBMIsCreateCommandRequest request)
        {
            ResultBMIsCreateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("ResultBMIsList", "Result");
            }
            else
            {
                return RedirectToAction("ResultBMIsCreate", "Result");
            }
        }

        [HttpGet]
        public async Task<IActionResult> ResultBMIsUpdate(GetByIdResultBMIQueryRequest request)
        {
            GetByIdResultBMIQueryResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return View(response.ResultBMI);
            }
            else
            {
                return RedirectToAction("ResultBMIsList", "Result");
            }            
        }

        [HttpPost]
        public async Task<IActionResult> ResultBMIsUpdate(ResultBMIsUpdateCommandRequest request)
        {
            ResultBMIsUpdateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("ResultBMIsList", "Result");
            }
            else
            {
                return RedirectToAction("ResultBMIsUpdate", "Result");
            }
        }

        public async Task<IActionResult> ResultBMIsDelete(ResultBMIsDeleteCommandRequest request)
        {
            ResultBMIsDeleteCommandResponse response = await _mediator.Send(request);
            return RedirectToAction("ResultBMIsList", "Result");
        }

        #endregion

        #region ResultOptimums

        [HttpGet]
        public async Task<IActionResult> ResultOptimumsList(GetAllResultOptimumsQueryRequest request)
        {
            GetAllResultOptimumsQueryResponse response = await _mediator.Send(request);
            return View(response.ResultOptimums);
        }

        [HttpGet]
        public IActionResult ResultOptimumsCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResultOptimumsCreate(ResultOptimumsCreateCommandRequest request)
        {
            ResultOptimumsCreateCommandResponse response = await _mediator.Send(request);

            if (response.State)
            {
                return RedirectToAction("ResultOptimumsList", "Result");
            }
            else
            {
                return RedirectToAction("ResultOptimumsCreate", "Result");
            }
        }

        [HttpGet]
        public async Task<IActionResult> ResultOptimumsUpdate(GetByIdResultOptimumQueryRequest request)
        {
            GetByIdResultOptimumQueryResponse response = await _mediator.Send(request);
            
            if (response.State)
            {
                return View(response.ResultOptimum);
            }
            else
            {
                return RedirectToAction("ResultOptimumsList", "Result");
            }
        }

        [HttpPost]
        public async Task<IActionResult> ResultOptimumsUpdate(ResultOptimumsUpdateCommandRequest request)
        {
            ResultOptimumsUpdateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("ResultOptimumsList", "Result");
            }
            else
            {
                return RedirectToAction("ResultOptimumsUpdate", "Result");
            }
        }

        public async Task<IActionResult> ResultOptimumsDelete(ResultOptimumsDeleteCommandRequest request)
        {
            ResultOptimumsDeleteCommandResponse response = await _mediator.Send(request);
            return RedirectToAction("ResultOptimumsList", "Result");
        }

        #endregion

        #region ResultPulses

        [HttpGet]
        public async Task<IActionResult> ResultPulsesList(GetAllResultPulseQueryRequest request)
        {
            GetAllResultPulseQueryResponse response = await _mediator.Send(request);
            return View(response.ResultPulses);
        }

        [HttpGet]
        public IActionResult ResultPulsesCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResultPulsesCreate(ResultPulsesCreateCommandRequest request)
        {
            ResultPulsesCreateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("ResultPulsesList", "Result");
            }
            else
            {
                return RedirectToAction("ResultPulsesCreate", "Result");
            }
        }

        [HttpGet]
        public async Task<IActionResult> ResultPulsesUpdate(GetByIdResultPulseQueryRequest request)
        {
            GetByIdResultPulseQueryResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return View(response.ResultPulse);
            }
            else
            {
                return RedirectToAction("ResultPulsesList", "Result");
            }            
        }

        [HttpPost]
        public async Task<IActionResult> ResultPulsesUpdate(ResultPulsesUpdateCommandRequest request)
        {
            ResultPulsesUpdateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("ResultPulsesList", "Result");
            }
            else
            {
                return RedirectToAction("ResultPulsesUpdate", "Result");
            }
        }

        public async Task<IActionResult> ResultPulsesDelete(ResultPulsesDeleteCommandRequest request)
        {
            ResultPulsesDeleteCommandResponse response = await _mediator.Send(request);
            return RedirectToAction("ResultPulsesList", "Result");
        }

        #endregion
    }
}
