using MediatR;
using Microsoft.AspNetCore.Mvc;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Features.Commands.IUHome.NewsBulletin;
using MVCBlogApp.Application.Features.Commands.IUHome.UploadImage;
using MVCBlogApp.Application.Features.Queries.UIHome.GetBiography;
using MVCBlogApp.Application.Features.Queries.UIHome.GetPage;
using MVCBlogApp.Application.Features.Queries.UIHome.GetReferences;
using MVCBlogApp.Application.Features.Queries.UIHome.GetSearchData;
using MVCBlogApp.Application.Features.Queries.UIHome.GetSeminarVisuals;
using MVCBlogApp.Application.Features.Queries.UIHome.OurTeam;
using MVCBlogApp.Application.Features.Queries.UIHome.UIHomeIndex;
using MVCBlogApp.Application.Features.Queries.UIHome.Video;
using MVCBlogApp.Application.Features.Queries.UIHome.VideoPartialView;
using MVCBlogApp.Application.ViewModels;
using MVCBlogApp.Application.Helpers;
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

        ////////////////////////////   Search,SearchPartialView, Video ve VideoPartialView paged(sayfalama) işlemi uygulanacaktır.
        ///

        [Route("taylan-kumeli-videolari")]
        public async Task<IActionResult> Video()
        {
            VideoQueryRequest request = new();
            VideoQueryResponse response = await _mediator.Send(request);

            if (response.Videos == null)
                return NotFound();

            TempData["Title"] = "Video";
            return View(response.Videos);
        }

        //[Route("video-partial-view")]
        //[HttpPost]
        //public async Task<JsonResult> VideoPartialView(VideoPartialViewQueryRequest request)
        //{
        //    VideoPartialViewQueryResponse response = await _mediator.Send(request);

        //    VM_ReturnViewString r = new();
        //    r.Status = 200;
        //    r.ViewString = this.RenderViewAsync("VideoPartialView", response.Result, true).Result;
        //    return Json(r);
        //}


        //[Route("danisan-itiraflari-partial-view")]
        //[HttpPost]
        //public JsonResult ConfessionsPartialView(int page = 1)
        //{
        //    var model = _dataContext.Confession.Where(s => s.StatusID == 1 && s.IsAprove == true).OrderByDescending(s => s.ID).GetPaged(page, 5);

        //    ReturnViewString r = new ReturnViewString();
        //    r.Status = 200;
        //    r.ViewString = this.RenderViewAsync("ConfessionsPartialView", model, true).Result;
        //    return Json(r);
        //}

        [Route("danisan-itiraflari")]
        [Route("members-of-confession")]
        public IActionResult Danisan()
        {
            int LangID = _operationService.SessionLangId();

            if (LangID == 2)
            {
                TempData["Title"] = "Members of confession";

            }
            else
            {
                TempData["Title"] = "Danışan İtirafları";

            }

            return View();
        }

        //[HttpPost]
        //[Route("danisan-itiraflari")]
        //[Route("members-of-confession")]
        //public IActionResult Danisan(ConfessionModel model)
        //{
        //    try
        //    {
        //        Confession confession = new Confession()
        //        {
        //            MemberName = model.MemberName,
        //            MemberConfession = model.MemberConfession,
        //            IsVisible = !model.IsVisible,
        //            IsAprove = false,
        //            IsRead = false,
        //            StatusID = 1,
        //            CreateDatetime = DateTime.Now
        //        };

        //        _dataContext.Confession.Add(confession);
        //        _dataContext.SaveChanges();

        //        try
        //        {
        //            string isVisibleString = model.IsVisible ? "Hayır" : "Evet";

        //            string body = $@"
        //            {model.MemberName} İsimli Danışan yeni bir Danışan İtiraf formu gönderdi. 
        //            <br>
        //            <br>
        //            <b>Danışan Adı Soyadı:</b> {model.MemberName}
        //            <br>
        //            <b>İsim Görünsün Mü :</b> {isVisibleString}
        //            <br>
        //            <b>Danışan İtirafı:</b>  <br> {model.MemberConfession}
        //            ";

        //            MailHelper.SendMail(
        //                "cansu@taylankumeli.com,info@taylankumeli.com,ceren@taylankumeli.com",
        //                "Tarafınıza Yeni Bir Danışan Formu Gönderildi",
        //                body,
        //                null,
        //                "karahasan.ayse@gmail.com,udavutoglu@yahoo.com"
        //                );

        //            //MailHelper.SendMail("cansu@taylankumeli.com,info@taylankumeli.com,ceren@taylankumeli.com ", "Tarafınıza Yeni Bir İletişim Formu Gönderildi",contactModel.NameSurname +" İsimli Danışan yeni bir iletişim formu gönderdi");
        //        }
        //        catch (Exception e)
        //        {

        //        }

        //        ViewBag.Result = "Success";
        //    }
        //    catch (Exception ex)
        //    {
        //        ViewBag.Result = "Error";
        //        ViewBag.Message = ex.Message;
        //    }
        //    return View(model);
        //}



        [Route("Ekibimiz")]
        public async Task<IActionResult> OurTeam()
        {
            OurTeamQueryRequest request = new();
            OurTeamQueryResponse response = await _mediator.Send(request);

            if (response.OurTeam == null)
                return NotFound();

            return View(response.OurTeam);
        }

        [Route("seminer-gorselleri")]
        [Route("seminar-visuals")]
        public async Task<IActionResult> SeminerGorselleri()
        {
            GetSeminarVisualsQueryRequest request = new();
            GetSeminarVisualsQueryResponse response = await _mediator.Send(request);

            int LangID = _operationService.SessionLangId();

            if (LangID == 2)
            {
                TempData["Title"] = "Seminar Visuals";
            }
            else
            {
                TempData["Title"] = "Seminer Görselleri";
            }


            if (response.SeminarVisuals == null)
                return NotFound();

            return View(response.SeminarVisuals);
        }

        [Route("kurumsal-referanslar")]
        [Route("corporate-references")]
        public async Task<IActionResult> KurumsalReferanslar()
        {
            GetReferencesQueryRequest request = new();
            GetReferencesQueryResponse response = await _mediator.Send(request);

            int LangID = _operationService.SessionLangId();

            if (LangID == 2)
            {
                TempData["Title"] = "Corporate References";

            }
            else
            {
                TempData["Title"] = "Kurumsal Referanslar";

            }

            if (response.References == null)
                return NotFound();

            return View(response.References);
        }

        [Route("/Home/NewsBulletin")]
        public async Task<JsonResult> NewsBulletin(NewsBulletinCommandRequest request)
        {
            NewsBulletinCommandResponse response = await _mediator.Send(request);

            int LangID = _operationService.SessionLangId();

            if (response.State)
            {
                if (LangID == 2)
                {
                    return Json(new { result = "Your registration has been taken" });

                }
                else
                {
                    return Json(new { result = "Kaydınız Alınmıştır." });

                }
            }
            else
            {
                return Json(new { result = "E-Postanızı kontrol ediniz" });
            }
        }
    }
}
