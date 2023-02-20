using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using MVCBlogApp.Application.Features.Commands.Home.CreateUser;
using MVCBlogApp.Application.Features.Commands.Home.PasswordReset;
using MVCBlogApp.Application.Features.Queries.Home.Login;
using MVCBlogApp.UI.Models;
using NuGet.Protocol;
using System.Diagnostics;
using System.Security.Claims;

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

                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, response.AuthRole),
                        new Claim(ClaimTypes.Role,response.Role.ToString()),
                        new Claim(ClaimTypes.Sid,response.Id.ToString()),
                        new Claim(ClaimTypes.Email,response.Email)
                    };
                var claimsidentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties()
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTime.UtcNow.AddHours(1)
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsidentity), authProperties);



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
                if (response.AuthRole == "Danışan")
                {
                    return RedirectToAction("Index", "Admin");
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

        [HttpGet]
        public IActionResult PasswordReset()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PasswordReset(PasswordResetCommandRequest request)
        {
            PasswordResetCommandResponse response = await _mediator.Send(request);
            if (response.Status)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                return RedirectToAction("PasswordReset", "Home");
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