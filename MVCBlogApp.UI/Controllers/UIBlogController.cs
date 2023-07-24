using MediatR;
using Microsoft.AspNetCore.Mvc;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Features.Queries.UIBlog.BasariHikayeleriPartialView;
using MVCBlogApp.Application.Features.Queries.UIBlog.BlogCategoryIndex;
using MVCBlogApp.Application.Features.Queries.UIBlog.UIBlogPartialView;
using MVCBlogApp.Application.Features.Queries.UIBlog.YemekTarifleriPartialView;
using MVCBlogApp.Application.Helpers;
using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.UI.Controllers
{
    public class UIBlogController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IOperationService _operationService;

        public UIBlogController(IMediator mediator, IOperationService operationService)
        {
            _mediator = mediator;
            _operationService = operationService;
        }
        [Route("/Blog/")]
        public IActionResult Index()
        {
            int LangID = _operationService.SessionLangId();

            if (LangID == 2)
            {
                TempData["Title"] = "Blog";

            }
            else
            {
                TempData["Title"] = "Blog";

            }
            return View();
        }

        [Route("blog-partial-view")]
        [HttpPost]
        public async Task<JsonResult> BlogPartialView(UIBlogPartialViewQueryRequest request)
        {
            UIBlogPartialViewQueryResponse response = await _mediator.Send(request);

            VM_ReturnViewString r = new();
            r.Status = 200;
            r.ViewString = this.RenderViewAsync("BlogPartialView", response.Result, true).Result;
            return Json(r);
        }

        public async Task<IActionResult> BlogCategoryIndex(BlogCategoryIndexQueryRequest request)
        {
            BlogCategoryIndexQueryResponse response = await _mediator.Send(request);

            return View("Index", response.Blogs);
        }

        [Route("basari-hikayeleri")]
        [Route("success-history")]
        public IActionResult Basari()
        {
            int LangID = _operationService.SessionLangId();

            if (LangID == 2)
            {
                TempData["Title"] = "Success History";

            }
            else
            {
                TempData["Title"] = "Başarı Hikayeleri";

            }

            return View();
        }

        [Route("basari-hikayeleri-partial-view")]
        [HttpPost]
        public async Task<JsonResult> BasariHikayeleriPartialView(BasariHikayeleriPartialViewQueryRequest request)
        {
            BasariHikayeleriPartialViewQueryResponse response = await _mediator.Send(request);

            VM_ReturnViewString r = new();
            r.Status = 200;
            r.ViewString = this.RenderViewAsync("BasariHikayeleriPartialView", response.Result, true).Result;
            return Json(r);
        }

        [Route("yemek-tarifleri")]
        [Route("recipes")]
        public IActionResult Yemek()
        {
            int LangID = _operationService.SessionLangId();

            if (LangID == 2)
            {
                TempData["Title"] = "Recipes";

            }
            else
            {
                TempData["Title"] = "Yemek Tarifleri";

            }

            return View();
        }


        [Route("yemek-tarifleri-partial-view")]
        [HttpPost]
        public async Task<JsonResult> YemekTarifleriPartialView(YemekTarifleriPartialViewQueryRequest request)
        {
            YemekTarifleriPartialViewQueryResponse response = await _mediator.Send(request);            

            VM_ReturnViewString r = new();
            r.Status = 200;
            r.ViewString = this.RenderViewAsync("YemekTarifleriPartialView", response.Result, true).Result;
            return Json(r);
        }
    }
}
