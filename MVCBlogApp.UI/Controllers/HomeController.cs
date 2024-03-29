﻿using MediatR;
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

        [Route("Danisan/uye-ol")]
        [Route("Members/Register")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [Route("Danisan/uye-ol")]
        [Route("Members/Register")]
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
        [Route("Danisan/uye-giris")]
        [Route("Members/Login")]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [Route("Danisan/uye-giris")]
        [Route("Members/Login")]
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
                        new Claim(ClaimTypes.Role,response.AuthRole),
                        new Claim(ClaimTypes.Sid,response.Id.ToString()),
                        new Claim(ClaimTypes.Email,response.Email),
                        new Claim(ClaimTypes.Surname,response.Role.ToString())
                    };
                var claimsidentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties()
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTime.UtcNow.AddHours(1)
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsidentity), authProperties);


                if (response.AuthRole == "Admin")
                {
                    return RedirectToAction("Index", "Admin");
                }
                else if (response.AuthRole == "Diyetisyen")
                {
                    return RedirectToAction("Index", "Doctor");
                }
                else
                {
                    return RedirectToAction("Index", "Member");
                }               
            }
            else
            {
                return RedirectToAction("Login","Home");
            }            
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {            
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            foreach (var cookie in Request.Cookies.Keys)
            {
                Response.Cookies.Delete(cookie);
            }
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Home");
        }


        [Route("Danisan/sifre-sifirla")]
        [Route("Members/password-reset")]
        [HttpGet]
        public IActionResult PasswordReset()
        {
            return View();
        }

        [Route("Danisan/sifre-sifirla")]
        [Route("Members/password-reset")]
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