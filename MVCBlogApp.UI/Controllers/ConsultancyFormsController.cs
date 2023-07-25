using MediatR;
using Microsoft.AspNetCore.Mvc;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Features.Commands.ConsultancyForms.ConsultancyFormsCreate;

namespace MVCBlogApp.UI.Controllers
{
    public class ConsultancyFormsController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IOperationService _operationService;

        public ConsultancyFormsController(IMediator mediator, IOperationService operationService)
        {
            _mediator = mediator;
            _operationService = operationService;
        }

        [Route("Form/{id}")]
        public IActionResult ConsultancyForms(string id)
        {
            if (id == "bireysel-beslenme-danismanligi-formu")
            {
                ViewBag.TypeName = "Bireysel Beslenme Danışmanlığı Formu";
                TempData["Title"] = "Bireysel Beslenme Danışmanlığı Formu";


            }
            else if (id == "kurumsal-beslenme-danismanligi-formu")
            {
                ViewBag.TypeName = "Kurumsal Beslenme Danışmanlığı Formu";
                TempData["Title"] = "Kurumsal Beslenme Danışmanlığı Formu";

            }

            else if (id == "cocuklar-icin-beslenme-danismanligi-formu")
            {
                ViewBag.TypeName = "Çocuklar İçin Beslenme Danışmanlığı Formu";
                TempData["Title"] = "Çocuklar İçin Beslenme Danışmanlığı Formu";
            }



            else if (id == "individual-nutrition-counseling-form")
            {
                ViewBag.TypeName = "INDIVIDUAL NUTRITION CONSULTANCY";
                TempData["Title"] = "INDIVIDUAL NUTRITION CONSULTANCY";
            }

            else if (id == "corporate-nutrition-consultancy-form")
            {
                ViewBag.TypeName = "CORPORATE NUTRITION CONSULTANCY";
                TempData["Title"] = "CORPORATE NUTRITION CONSULTANCY";
            }
            else if (id == "nutrition-counseling-for-children-form")
            {
                ViewBag.TypeName = "NUTRITION CONSULTANCY FOR CHILDREN";
                TempData["Title"] = "NUTRITION CONSULTANCY FOR CHILDREN";
            }
            else
            {
                return NotFound();

            }

            return View();

        }

        [Route("Form/{id}")]
        [HttpPost]
        public async Task<IActionResult> ConsultancyForms(ConsultancyFormsCreateCommandRequest request)
        {
            ConsultancyFormsCreateCommandResponse response = await _mediator.Send(request);

            if (response.State)
            {
                TempData["Message"] = "Mesajınız Tarafımıza Ulaşmıştır.";
            }
            else
            {
                TempData["Message"] = "Lütfen Alanları Geçerli Değerler İle Doldurunuz.";
            }

            return View(request);
        }
    }
}
