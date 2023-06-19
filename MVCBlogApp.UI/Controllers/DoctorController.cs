using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Features.Queries.Doctor.Dashboard;

namespace MVCBlogApp.UI.Controllers
{
    [Authorize(Roles = "Diyetisyen")]
    public class DoctorController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IOperationService _operationService;

        public DoctorController(IMediator mediator, IOperationService operationService)
        {
            _mediator = mediator;
            _operationService = operationService;
        }

        public async Task<IActionResult> Index(GetDoctorDashboardItemListQueryRequest request)
        {
            request.Id = _operationService.GetUser().Id;
            GetDoctorDashboardItemListQueryResponse response = await _mediator.Send(request);
            return View(response);
        }
    }
}
