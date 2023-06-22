using Microsoft.AspNetCore.Mvc;

namespace MVCBlogApp.UI.Models.ViewComponents
{
    public class UIHomeCalcTests : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
