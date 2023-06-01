using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.UI.Controllers
{
    [Authorize(Roles = "Danışan")]
    public class MemberController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IOperationService _operationService;

        public MemberController(IMediator mediator, IOperationService operationService)
        {
            _mediator = mediator;
            _operationService = operationService;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region MemberInfo

        [HttpGet]
        public async Task<IActionResult> MemberInfoView()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> MemberInfoCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> MemberInfoCreate(int a)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> MemberInfoUpdate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> MemberInfoUpdate(int a)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> MemberInfoDelete()
        {
            return View();
        }

        #endregion

    }
}
