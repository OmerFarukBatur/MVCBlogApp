using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCBlogApp.Application.Features.Queries.Calc.CalcBmhs.GetAllCalcBmhs;
using MVCBlogApp.Application.Features.Queries.Calc.CalcBMIs.GetAllCalcBMIs;
using MVCBlogApp.Application.Features.Queries.Calc.CalcOptimums.GetAllCalcOptimums;
using MVCBlogApp.Application.Features.Queries.Calc.CalcPulses.GetAllCalcPulses;

namespace MVCBlogApp.UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CalcController : Controller
    {
        private readonly IMediator _mediator;

        public CalcController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region CalcBmhs

        [HttpGet]
        public async Task<IActionResult> CalcBmhsList(GetAllCalcBmhsQueryRequest request)
        {
            GetAllCalcBmhsQueryResponse response = await _mediator.Send(request);
            return View(response.CalcBmhs);
        }

        #endregion

        #region CalcBMIs

        [HttpGet]
        public async Task<IActionResult> CalcBMIsList(GetAllCalcBMIsQueryRequest request)
        {
            GetAllCalcBMIsQueryResponse response = await _mediator.Send(request);
            return View(response.CalcBMIs);
        }
        
        #endregion

        #region CalcOptimums

        [HttpGet]
        public async Task<IActionResult> CalcOptimumsList(GetAllCalcOptimumsQueryRequest request)
        {
            GetAllCalcOptimumsQueryResponse response = await _mediator.Send(request);
            return View(response.CalcOptimums);
        }
       
        #endregion

        #region CalcPulses

        [HttpGet]
        public async Task<IActionResult> CalcPulsesList(GetAllCalcPulsesQueryRequest request)
        {
            GetAllCalcPulsesQueryResponse response = await _mediator.Send(request);
            return View(response.CalcPulses);
        }
        
        #endregion
    }
}
