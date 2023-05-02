using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.UI.Controllers
{
    [Authorize(Roles = "Diyetisyen")]
    public class DoctorReportProccessController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IGeneralOptionsService _generalOptionsService;

        public DoctorReportProccessController(IMediator mediator, IGeneralOptionsService generalOptionsService)
        {
            _mediator = mediator;
            _generalOptionsService = generalOptionsService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
