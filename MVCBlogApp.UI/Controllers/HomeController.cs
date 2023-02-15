using MediatR;
using Microsoft.AspNetCore.Mvc;
using MVCBlogApp.Application.Features.Commands.Home.CreateUser;
using MVCBlogApp.Application.Features.Queries.Home.Login;
using MVCBlogApp.UI.Models;
using NuGet.Protocol;
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
            if (response.StatusCode)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                return View(response);
            }            
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginQueryRequest request)
        {
            LoginQueryResponse response = await _mediator.Send(request);
            if (response.Id > 0)
            {
                HttpContext.Session.SetString("users", response.ToJson());
                //switch (response.Role)
                //{
                //    case "Danışan":
                //        RedirectToAction("Index", "Admin");
                //        break;
                //    case "Admin":
                //        break;
                //    case "Moderator":
                //        break;
                //    case "Diyetisyen":
                //        break;
                //    case "Asistan":
                //        break;
                //    default:
                //        RedirectToAction("Index","Admin");
                //        break;
                //}
                if (response.Role)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Index", "Admin");
                }
               
            }
            else
            {
                return RedirectToAction("Login","Home");
            }            
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