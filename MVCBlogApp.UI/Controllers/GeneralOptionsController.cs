using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCBlogApp.Application.Features.Commands.GeneralOptions.CreateLanguage;
using MVCBlogApp.Application.Features.Queries.GeneralOptions.GetAllLanguage;

namespace MVCBlogApp.UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class GeneralOptionsController : Controller
    {
        private readonly IMediator _mediator;

        public GeneralOptionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index(GetAllLanguageQueryRequest request)
        {
            GetAllLanguageQueryResponse response = await _mediator.Send(request);
            return View(response.AllLanguages);
        }

        [HttpGet]
        public IActionResult CreateLanguage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateLanguage(CreateLanguageCommandRequest request)
        {
            CreateLanguageCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("Index", "GeneralOptions");
            }
            else
            {
                return RedirectToAction("CreateLanguage", "GeneralOptions");
            }
        }
        public async Task<IActionResult> UpdateLanguage()
        {
            return View();
        }
        public async Task<IActionResult> UpdateLanguage(int b)
        {
            return View();
        }
        public async Task<IActionResult> DeleteLanguage()
        {
            return View();
        }
    }
}
