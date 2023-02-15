using Microsoft.AspNetCore.Mvc;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Features.Queries.Home.Login;
using MVCBlogApp.Application.ViewModels;
using MVCBlogApp.Domain.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NuGet.Protocol;
using System.Linq;

namespace MVCBlogApp.UI.Models.ViewComponents
{
    public class Sidebar : ViewComponent
    {
        private readonly IOperationService _operationService;

        public Sidebar(IOperationService operationService)
        {
            _operationService = operationService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            string[] seperator = { ",",":"};
            JObject valuePairs = JObject.Parse(HttpContext.Session.GetString("users")); 
            SessionUser user = _operationService.GetUser(valuePairs);
            return View(user);
        }
    }
}
