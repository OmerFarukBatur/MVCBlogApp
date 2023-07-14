﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Features.Commands.IUHome.UploadImage;
using MVCBlogApp.Application.Features.Queries.UIHome.GetBiography;
using MVCBlogApp.Application.Features.Queries.UIHome.GetPage;
using MVCBlogApp.Application.Features.Queries.UIHome.GetSearchData;
using MVCBlogApp.Application.Features.Queries.UIHome.UIHomeIndex;
using MVCBlogApp.Application.ViewModels;
using MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.UI.Controllers
{
    public class UIHomeController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IOperationService _operationService;

        public const string SessionOrderNo = "_OrderNo";
        public const string SessionParentID = "_ParentID";
        public const string SessionInternalID = "_InternalID";

        public UIHomeController(IMediator mediator, IOperationService operationService)
        {
            _mediator = mediator;
            _operationService = operationService;
        }

        public async Task<IActionResult> Index()
        {
            UIHomeIndexQueryRequest request = new();
            UIHomeIndexQueryResponse response = await _mediator.Send(request);

            if (response.LangId == 2)
            {

                TempData["Title"] = "Taylan Kümeli | Diet and Nutrition Programs for a Healthy and Balanced Life";
            }
            else
            {

                TempData["Title"] = "Taylan Kümeli | Sağlıklı ve Dengede Bir Yaşam İçin Diyet ve Beslenme Programları";
            }

            if (response.TaylanK == null)
            {
                return NotFound();
            }
            else
            {
                TempData["MetaKey"] = response.TaylanK.Metakey;
                TempData["MetaDescription"] = response.TaylanK.Metadescription;
                TempData["MetaTitle"] = response.TaylanK.Metatitle;
            }
            return View();
        }

        [Route("upload-image")]
        [HttpPost]
        public async Task<IActionResult> UploadImage(UploadImageCommandRequest request)
        {
            UploadImageCommandResponse response = await _mediator.Send(request);
            return Json(response.LocalUploadFile);
        }

        [Route("upload-image&responseType=json")]
        [HttpPost]
        public async Task<IActionResult> UploadImageWithType(UploadImageCommandRequest request)
        {
            UploadImageCommandResponse response = await _mediator.Send(request);
            return Json(response.LocalUploadFile);
        }

        [Route("ckeditor-test")]
        public IActionResult CkEditorTest()
        {
            return View();
        }

        [Route("{id}")]
        public async Task<IActionResult> GetPage(GetPageQueryRequest request)
        {
            GetPageQueryResponse response = await _mediator.Send(request);

            if (response.Blog != null)
            {
                TempData["MetaKey"] = response.Blog.MetaKey;
                TempData["MetaDescription"] = response.Blog.MetaDescription;
                TempData["MetaTitle"] = response.Blog.MetaTitle;
                TempData["Title"] = response.Blog.Title;

                ViewBag.tip = response.Blog.BlogTypeName;

                return View("~/Views/Blog/Detail.cshtml", response.Blog);
            }

            else if (response.Article != null)
            {

                TempData["MetaKey"] = response.Article.MetaKey;
                TempData["MetaDescription"] = response.Article.MetaDescription;
                TempData["MetaTitle"] = response.Article.MetaTitle;
                TempData["Title"] = response.Article.Title;


                if (TempData["orderNo"] is string && TempData["parentID"] is int)
                {
                    HttpContext.Session.SetString(SessionOrderNo, (string)TempData["orderNo"]);
                    HttpContext.Session.SetInt32(SessionParentID, (int)TempData["parentID"]);
                    HttpContext.Session.SetInt32(SessionInternalID, (int)TempData["internalID"]);
                }
                else
                {
                    TempData["orderNo"] = response.NavigationOrderId;
                    TempData["parentID"] = response.Article.NavigationId;
                    TempData["internalID"] = response.Article.Id;
                }

                return View("~/Views/Article/Index.cshtml", response.Article);
            }

            else if (response.Book != null)
            {


                TempData["MetaKey"] = response.Book.Action;
                TempData["MetaDescription"] = response.Book.BookName;
                TempData["MetaTitle"] = response.Book.BookName;
                TempData["Title"] = response.Book.BookName;

                if (TempData["orderNo"] is string && TempData["parentID"] is int && TempData["internalID"] is int)
                {
                    HttpContext.Session.SetString(SessionOrderNo, (string)TempData["orderNo"]);
                    HttpContext.Session.SetInt32(SessionParentID, (int)TempData["parentID"]);
                    HttpContext.Session.SetInt32(SessionInternalID, (int)TempData["internalID"]);
                }
                else
                {
                    TempData["orderNo"] = response.NavigationOrderId;
                    TempData["parentID"] = response.Book.NavigationId;
                    TempData["internalID"] = response.Book.Id;
                }

                return View("~/Views/Book/Edit.cshtml", response.Book);
            }

            else if (response.Press != null)
            {
                TempData["MetaKey"] = response.Press.MetaKey;
                TempData["MetaDescription"] = response.Press.MetaDescription;
                TempData["MetaTitle"] = response.Press.MetaTitle;
                TempData["Title"] = response.Press.Title;

                return View("~/Views/Press/Detail.cshtml", response.Press);
            }

            else if (response.MasterRoot != null)
            {
                if (response.MasterRoot.Controller == "Form")
                {

                    return View("~/Views/ConsultancyForms/ConsultancyForms.cshtml");
                }
            }

            return NotFound();
        }

        [Route("taylan-kumeli-kimdir")]
        public async Task<IActionResult> TaylanKumeliKimdir()
        {
            GetBiographyQueryRequest request = new();
            GetBiographyQueryResponse response = await _mediator.Send(request);

            if (response.TaylanK == null)
            {
                return NotFound();
            }

            TempData["MetaKey"] = response.TaylanK.Metakey;
            TempData["MetaDescription"] = response.TaylanK.Metadescription;
            TempData["MetaTitle"] = response.TaylanK.Metatitle;

            return View();
        }

        [Route("Home/search")]
        public async Task<IActionResult> Search(GetSearchDataQueryRequest request)
        {
            GetSearchDataQueryResponse response = await _mediator.Send(request);

            ViewBag.search = request.QueryKeyword.ToString();

            return View(response.Searches);
        }
    }
}
