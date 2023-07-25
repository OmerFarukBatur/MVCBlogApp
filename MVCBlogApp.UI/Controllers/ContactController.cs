using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Features.Commands.Contact.ContactCreate;
using MVCBlogApp.Application.Features.Queries.GeneralOptions.ContactCategory.GetAllContactCategory;

namespace MVCBlogApp.UI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IOperationService _operationService;

        public ContactController(IMediator mediator, IOperationService operationService)
        {
            _mediator = mediator;
            _operationService = operationService;
        }

        [Route("iletisim")]
        [Route("Contact")]
        public async Task<IActionResult> Index()
        {

            int LangID = _operationService.SessionLangId();

            if (LangID == 2)
            {
                TempData["Title"] = "Contact Form";

            }
            else
            {
                TempData["Title"] = "İletişim Formu";

            }
            GetAllContactCategoryQueryRequest request = new();
            GetAllContactCategoryQueryResponse response = await _mediator.Send(request);

            ViewData["ContactCategoryID"] = new SelectList(response.ContactCategories.Where(x => x.LangId == LangID), "Id", "ContactCategoryName");
            return View();
        }


        [HttpPost]
        [Route("iletisim")]
        [Route("Contact")]
        public async Task<IActionResult> Index(ContactCreateCommandRequest request)
        {
            ContactCreateCommandResponse response = await _mediator.Send(request);

            if (response.State)
            {
                int LangID = _operationService.SessionLangId();
                if (LangID == 2)
                {
                    TempData["Message"] = "İletişim formunuz gönderilmiştir.";
                }
                else
                {
                    TempData["Message"] = "Your contact form has been sent.";
                }
            }
            else
            {
                TempData["Message"] = "Kayıt Sırasında Hata Meydana Geldi";
            }
            return RedirectToAction("Index", "Contact");
        }
    }
}
