using MediatR;
using Microsoft.AspNetCore.Mvc;
using MVCBlogApp.Application.Features.Commands.Home.CreateUser;
using MVCBlogApp.UI.Models;
using System.Diagnostics;

namespace MVCBlogApp.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;


        private readonly IMediator _mediator;
        

        public HomeController(ILogger<HomeController> logger,IMediator mediator)
        {
            _mediator = mediator;
            _logger = logger;
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateUserCommandRequest request)
        {
            CreateUserCommandResponse response = await _mediator.Send(request);
            return View(response);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}