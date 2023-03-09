using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Features.Commands.Article.ArticleCategory.ArticleCategoryCreate;
using MVCBlogApp.Application.Features.Queries.Article.ArticleCategory.GetAllArticleCategory;
using MVCBlogApp.Application.Features.Queries.Article.ArticleCategory.GetArticleCategoryCreateItems;

namespace MVCBlogApp.UI.Controllers
{
    [Authorize(Roles ="Admin")]
    public class ArticleController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IOperationService _operationService;

        public ArticleController(IMediator mediator, IOperationService operationService)
        {
            _mediator = mediator;
            _operationService = operationService;
        }

        #region Article

        [HttpGet]
        public async Task<IActionResult> ArticleList()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ArticleCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ArticleCreate(int a)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ArticleUpdate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ArticleUpdate(int a)
        {
            return View();
        }

        
        public async Task<IActionResult> ArticleDelete()
        {
            return View();
        }

        #endregion

        #region ArticleCategory

        [HttpGet]
        public async Task<IActionResult> ArticleCategoryList(GetAllArticleCategoryQueryRequest request)
        {
            GetAllArticleCategoryQueryResponse response = await _mediator.Send(request);
            return View(response.ArticleCategories);
        }

        [HttpGet]
        public async Task<IActionResult> ArticleCategoryCreate(GetArticleCategoryCreateItemsQueryRequest request)
        {
            GetArticleCategoryCreateItemsQueryResponse response = await _mediator.Send(request);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> ArticleCategoryCreate(ArticleCategoryCreateCommandRequest request)
        {
            request.CreateUserId = _operationService.GetUser().Id;
            ArticleCategoryCreateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("ArticleCategoryList", "Article");
            }
            else
            {
                return RedirectToAction("ArticleCategoryCreate", "Article");
            }
        }

        [HttpGet]
        public async Task<IActionResult> ArticleCategoryUpdate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ArticleCategoryUpdate(int a)
        {
            return View();
        }


        public async Task<IActionResult> ArticleCategoryDelete()
        {
            return View();
        }

        #endregion
    }
}
