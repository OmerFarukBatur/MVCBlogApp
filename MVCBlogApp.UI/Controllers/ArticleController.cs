﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Features.Commands.Article.Article.ArticleCreate;
using MVCBlogApp.Application.Features.Commands.Article.Article.ArticleDelete;
using MVCBlogApp.Application.Features.Commands.Article.Article.ArticleUpdate;
using MVCBlogApp.Application.Features.Commands.Article.ArticleCategory.ArticleCategoryCreate;
using MVCBlogApp.Application.Features.Commands.Article.ArticleCategory.ArticleCategoryDelete;
using MVCBlogApp.Application.Features.Commands.Article.ArticleCategory.ArticleCategoryUpdate;
using MVCBlogApp.Application.Features.Queries.Article.Article.GetAllArticle;
using MVCBlogApp.Application.Features.Queries.Article.Article.GetArticleCreateItems;
using MVCBlogApp.Application.Features.Queries.Article.Article.GetByIdArticle;
using MVCBlogApp.Application.Features.Queries.Article.ArticleCategory.GetAllArticleCategory;
using MVCBlogApp.Application.Features.Queries.Article.ArticleCategory.GetArticleCategoryCreateItems;
using MVCBlogApp.Application.Features.Queries.Article.ArticleCategory.GetByIdArticleCategory;

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
        public async Task<IActionResult> ArticleList(GetAllArticleQueryRequest request)
        {
            GetAllArticleQueryResponse response = await _mediator.Send(request);
            return View(response.Articles);
        }

        [HttpGet]
        public async Task<IActionResult> ArticleCreate(GetArticleCreateItemsQueryRequest request)
        {
            GetArticleCreateItemsQueryResponse response = await _mediator.Send(request);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> ArticleCreate(ArticleCreateCommandRequest request)
        {
            request.CreateUserId = _operationService.GetUser().Id;
            ArticleCreateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("ArticleList", "Article");
            }
            else
            {
                return RedirectToAction("ArticleCreate", "Article");
            }
        }

        [HttpGet]
        public async Task<IActionResult> ArticleUpdate(GetByIdArticleQueryRequest request)
        {
            GetByIdArticleQueryResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return View(response);
            }
            else
            {
                return RedirectToAction("ArticleList", "Article");
            }
        }

        [HttpPost]
        public async Task<IActionResult> ArticleUpdate(ArticleUpdateCommandRequest request)
        {
            request.UpdateUserId = _operationService.GetUser().Id;
            ArticleUpdateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("ArticleList", "Article");
            }
            else
            {
                return RedirectToAction("ArticleUpdate", "Article");
            }
        }

        
        public async Task<IActionResult> ArticleDelete(ArticleDeleteCommandRequest request)
        {
            ArticleDeleteCommandResponse response = await _mediator.Send(request);
            return RedirectToAction("ArticleList", "Article");
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
        public async Task<IActionResult> ArticleCategoryUpdate(GetByIdArticleCategoryQueryRequest request)
        {
            GetByIdArticleCategoryQueryResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return View(response);
            }
            else
            {
                return RedirectToAction("ArticleCategoryList", "Article");
            }
        }

        [HttpPost]
        public async Task<IActionResult> ArticleCategoryUpdate(ArticleCategoryUpdateCommandRequest request)
        {
            ArticleCategoryUpdateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("ArticleCategoryList", "Article");
            }
            else
            {
                return RedirectToAction("ArticleCategoryUpdate", "Article");
            }
        }


        public async Task<IActionResult> ArticleCategoryDelete(ArticleCategoryDeleteCommandRequest request)
        {
            ArticleCategoryDeleteCommandResponse response = await _mediator.Send(request);
            return RedirectToAction("ArticleCategoryList", "Article");
        }

        #endregion
    }
}
