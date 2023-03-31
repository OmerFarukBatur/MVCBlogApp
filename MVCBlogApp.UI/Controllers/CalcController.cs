using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> CalcBmhsList()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CalcBmhsCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CalcBmhsCreate(int a)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CalcBmhsUpdate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CalcBmhsUpdate(int a)
        {
            return View();
        }
        public async Task<IActionResult> CalcBmhsDelete(int a)
        {
            return View();
        }

        #endregion

        #region CalcBMIs

        [HttpGet]
        public async Task<IActionResult> CalcBMIsList()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CalcBMIsCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CalcBMIsCreate(int a)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CalcBMIsUpdate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CalcBMIsUpdate(int a)
        {
            return View();
        }
        public async Task<IActionResult> CalcBMIsDelete(int a)
        {
            return View();
        }

        #endregion

        #region CalcOptimums

        [HttpGet]
        public async Task<IActionResult> CalcOptimumsList()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CalcOptimumsCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CalcOptimumsCreate(int a)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CalcOptimumsUpdate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CalcOptimumsUpdate(int a)
        {
            return View();
        }
        public async Task<IActionResult> CalcOptimumsDelete(int a)
        {
            return View();
        }

        #endregion

        #region CalcPulses

        [HttpGet]
        public async Task<IActionResult> CalcPulsesList()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CalcPulsesCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CalcPulsesCreate(int a)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CalcPulsesUpdate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CalcPulsesUpdate(int a)
        {
            return View();
        }
        public async Task<IActionResult> CalcPulsesDelete(int a)
        {
            return View();
        }

        #endregion
    }
}
