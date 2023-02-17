using Microsoft.AspNetCore.Mvc;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.ViewModels;

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
            SessionUser user = _operationService.GetUser();
            return View(user);
        }
    }
}
