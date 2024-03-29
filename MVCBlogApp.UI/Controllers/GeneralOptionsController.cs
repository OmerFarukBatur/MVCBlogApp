﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCBlogApp.Application.Features.Commands.GeneralOptions.Contact.ContactReadUpdate;
using MVCBlogApp.Application.Features.Commands.GeneralOptions.ContactCategory.ContactCategoryCreate;
using MVCBlogApp.Application.Features.Commands.GeneralOptions.ContactCategory.ContactCategoryDelete;
using MVCBlogApp.Application.Features.Commands.GeneralOptions.ContactCategory.ContactCategoryUpdate;
using MVCBlogApp.Application.Features.Commands.GeneralOptions.Form.FormCreate;
using MVCBlogApp.Application.Features.Commands.GeneralOptions.Form.FormDelete;
using MVCBlogApp.Application.Features.Commands.GeneralOptions.Form.FormUpdate;
using MVCBlogApp.Application.Features.Commands.GeneralOptions.Languages.CreateLanguage;
using MVCBlogApp.Application.Features.Commands.GeneralOptions.Languages.DeleteLanguage;
using MVCBlogApp.Application.Features.Commands.GeneralOptions.Languages.UpdateLanguage;
using MVCBlogApp.Application.Features.Commands.GeneralOptions.Navigation.NavigationCreate;
using MVCBlogApp.Application.Features.Commands.GeneralOptions.Navigation.NavigationDelete;
using MVCBlogApp.Application.Features.Commands.GeneralOptions.Navigation.NavigationUpdate;
using MVCBlogApp.Application.Features.Queries.GeneralOptions.Contact.GetAllContact;
using MVCBlogApp.Application.Features.Queries.GeneralOptions.ContactCategory.GetAllContactCategory;
using MVCBlogApp.Application.Features.Queries.GeneralOptions.ContactCategory.GetByIdContactCategory;
using MVCBlogApp.Application.Features.Queries.GeneralOptions.ContactCategory.GetContactCategoryCreateItems;
using MVCBlogApp.Application.Features.Queries.GeneralOptions.Form.GetAllForms;
using MVCBlogApp.Application.Features.Queries.GeneralOptions.Form.GetByIdForm;
using MVCBlogApp.Application.Features.Queries.GeneralOptions.Form.GetFormCreateItems;
using MVCBlogApp.Application.Features.Queries.GeneralOptions.Languages.GetAllLanguage;
using MVCBlogApp.Application.Features.Queries.GeneralOptions.Languages.GetByIdLanguage;
using MVCBlogApp.Application.Features.Queries.GeneralOptions.Navigation.GetAllNavigation;
using MVCBlogApp.Application.Features.Queries.GeneralOptions.Navigation.GetByIdNavigation;
using MVCBlogApp.Application.Features.Queries.GeneralOptions.Navigation.GetNavigationCreateItems;
using MVCBlogApp.Application.Features.Queries.GeneralOptions.URLCreate;

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
        public async Task<IActionResult> NavigationUpdate(NavigationUpdateCommandRequest request)
        {
            NavigationUpdateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("NavigationList", "GeneralOptions");
            }
            else
            {
                return RedirectToAction("NavigationUpdate", "GeneralOptions");
            }
        }


        public async Task<IActionResult> NavigationDelete(NavigationDeleteCommandRequest request)
        {
            NavigationDeleteCommandResponse response = await _mediator.Send(request);
            return RedirectToAction("NavigationList", "GeneralOptions");
        }

        #endregion

        #region URLCreate

        [HttpPost]
        public async Task<IActionResult> URLCreate(URLCreateQueryRequest request)
        {
            URLCreateQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        #endregion

        #region Form

        public async Task<IActionResult> FormList(GetAllFormsQueryRequest request)
        {
            GetAllFormsQueryResponse response = await _mediator.Send(request);
            return View(response.Forms);
        }

        [HttpGet]
        public async Task<IActionResult> FormCreate(GetFormCreateItemsQueryRequest request)
        {
            GetFormCreateItemsQueryResponse response = await _mediator.Send(request);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> FormCreate(FormCreateCommandRequest request)
        {
            FormCreateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("FormList", "GeneralOptions");
            }
            else
            {
                return RedirectToAction("FormCreate", "GeneralOptions");
            }
        }

        [HttpGet]
        public async Task<IActionResult> FormUpdate(GetByIdFormQueryRequest request)
        {
            GetByIdFormQueryResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return View(response);
            }
            else
            {
                return RedirectToAction("FormList", "GeneralOptions");
            }
        }

        [HttpPost]
        public async Task<IActionResult> FormUpdate(FormUpdateQueryRequest request)
        {
            FormUpdateQueryResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("FormList", "GeneralOptions");
            }
            else
            {
                return RedirectToAction("FormUpdate", "GeneralOptions");
            }
        }


        public async Task<IActionResult> FormDelete(FormDeleteCommandRequest request)
        {
            FormDeleteCommandResponse response = await _mediator.Send(request);
            return RedirectToAction("FormList", "GeneralOptions");
        }

        #endregion

        #region Contact

        public async Task<IActionResult> ContactList(GetAllContactQueryRequest request)
        {
            GetAllContactQueryResponse response = await _mediator.Send(request);
            return View(response.Contacts);
        }

        [HttpGet]
        public async Task<IActionResult> ContactReadUpdate(ContactReadUpdateCommandRequest request)
        {
            ContactReadUpdateCommandResponse response = await _mediator.Send(request);
            return RedirectToAction("ContactList", "GeneralOptions");
        }

        #endregion

        #region ContactCategory

        public async Task<IActionResult> ContactCategoryList(GetAllContactCategoryQueryRequest request)
        {
            GetAllContactCategoryQueryResponse response = await _mediator.Send(request);
            return View(response.ContactCategories);
        }

        [HttpGet]
        public async Task<IActionResult> ContactCategoryCreate(GetContactCategoryCreateItemsQueryRequest request)
        {
            GetContactCategoryCreateItemsQueryResponse response = await _mediator.Send(request);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> ContactCategoryCreate(ContactCategoryCreateCommandRequest request)
        {
            ContactCategoryCreateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("ContactCategoryList", "GeneralOptions");
            }
            else
            {
                return RedirectToAction("ContactCategoryCreate", "GeneralOptions");
            }
        }

        [HttpGet]
        public async Task<IActionResult> ContactCategoryUpdate(GetByIdContactCategoryQueryRequest request)
        {
            GetByIdContactCategoryQueryResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return View(response);
            }
            else
            {
                return RedirectToAction("ContactCategoryUpdate", "GeneralOptions");
            }
        }

        [HttpPost]
        public async Task<IActionResult> ContactCategoryUpdate(ContactCategoryUpdateCommandRequest request)
        {
            ContactCategoryUpdateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("ContactCategoryList", "GeneralOptions");
            }
            else
            {
                return RedirectToAction("ContactCategoryUpdate", "GeneralOptions");
            }
        }


        public async Task<IActionResult> ContactCategoryDelete(ContactCategoryDeleteCommandRequest request)
        {
            ContactCategoryDeleteCommandResponse response = await _mediator.Send(request);
            return RedirectToAction("ContactCategoryList", "GeneralOptions");
        }

        #endregion
    }
}
