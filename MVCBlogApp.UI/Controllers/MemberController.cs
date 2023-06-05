using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Features.Queries.Member.GetByIdMemberInfo;

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

        public async Task<IActionResult> Index()
        {
            GetByIdMemberInfoQueryRequest request = new GetByIdMemberInfoQueryRequest();
            request.Id = _operationService.GetUser().Id;
            GetByIdMemberInfoQueryResponse response = await _mediator.Send(request);

            if (response.State)
            {
                return View();
            }
            else
            {
                return RedirectToAction("MemberInfoCreate", "Member");
            }            
        }

        #region MemberInfo

        [HttpGet]
        public async Task<IActionResult> MemberInfoView(GetByIdMemberInfoQueryRequest request)
        {
            request.Id = _operationService.GetUser().Id;
            GetByIdMemberInfoQueryResponse response = await _mediator.Send(request);

            if (response.State)
            {
                return View(response.MemberAllDetail);
            }
            else
            {
                return RedirectToAction("MemberInfoCreate", "Member");
            }            
        }

        [HttpGet]
        public IActionResult MemberInfoCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> MemberInfoCreate(int HowDoYouFeel)
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
