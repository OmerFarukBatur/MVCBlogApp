using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCBlogApp.Application.Features.Commands.GeneralOptions.Languages.CreateLanguage;
using MVCBlogApp.Application.Features.Commands.GeneralOptions.Languages.DeleteLanguage;
using MVCBlogApp.Application.Features.Commands.GeneralOptions.Languages.UpdateLanguage;
using MVCBlogApp.Application.Features.Commands.GeneralOptions.Navigation.NavigationCreate;
using MVCBlogApp.Application.Features.Queries.GeneralOptions.Languages.GetAllLanguage;
using MVCBlogApp.Application.Features.Queries.GeneralOptions.Languages.GetByIdLanguage;
using MVCBlogApp.Application.Features.Queries.GeneralOptions.Navigation.GetAllNavigation;
using MVCBlogApp.Application.Features.Queries.GeneralOptions.Navigation.GetByIdNavigation;
using MVCBlogApp.Application.Features.Queries.GeneralOptions.Navigation.GetNavigationCreateItems;

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

        #region Languages
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
        [HttpGet]
        public async Task<IActionResult> UpdateLanguage(GetByIdLanguageQueryRequest request)
        {
            GetByIdLanguageQueryResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return View(response.Language);
            }
            else
            {
                return RedirectToAction("Index", "GeneralOptions");
            }
        }
        [HttpPost]
        public async Task<IActionResult> UpdateLanguage(UpdateLanguageCommandRequest request)
        {
            UpdateLanguageCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("Index", "GeneralOptions");
            }
            else
            {
                return RedirectToAction("UpdateLanguage", "GeneralOptions");
            }
        }
        public async Task<IActionResult> DeleteLanguage(DeleteLanguageCommandRequest request)
        {
            DeleteLanguageCommandResponse response = await _mediator.Send(request);
            return RedirectToAction("Index", "GeneralOptions");
        }
        #endregion

        #region Navigation

        public async Task<IActionResult> NavigationList(GetAllNavigationQueryRequest request)
        {
            GetAllNavigationQueryResponse response = await _mediator.Send(request);
            return View(response.AllNavigations);
        }

        [HttpGet]
        public async Task<IActionResult> NavigationCreate(GetNavigationCreateItemsCommandRequest request)
        {
            GetNavigationCreateItemsCommandResponse response= await _mediator.Send(request);
            return View(new {response.Navigations,response.Languages});
        }

        [HttpPost]
        public async Task<IActionResult> NavigationCreate(NavigationCreateCommandRequest request)
        {
            NavigationCreateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("NavigationList", "GeneralOptions");
            }
            else
            {
                return RedirectToAction("NavigationCreate", "GeneralOptions");
            }
        }

        [HttpGet]
        public async Task<IActionResult> NavigationUpdate(GetByIdNavigationQueryRequest request)
        {
            GetByIdNavigationQueryResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return View(response);
            }
            else
            {
                return RedirectToAction("NavigationList", "GeneralOptions");
            }            
        }

        [HttpPost]
        public async Task<IActionResult> NavigationUpdate(int a)
        {

            return View();
        }


        public async Task<IActionResult> NavigationDelete()
        {

            return View();
        }
        #endregion
    }
}
