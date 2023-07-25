using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Features.Queries.UIBook.GetAllActiveBooks;
using MVCBlogApp.Application.Features.Queries.UIBook.GetBookDetail;

namespace MVCBlogApp.UI.Controllers
{
    public class UIBookController : Controller
    {
        public const string SessionOrderNo = "_OrderNo";
        public const string SessionParentID = "_ParentID";
        public const string SessionInternalID = "_InternalID";

        private readonly IMediator _mediator;
        private readonly IOperationService _operationService;

        public UIBookController(IMediator mediator, IOperationService operationService)
        {
            _mediator = mediator;
            _operationService = operationService;
        }

        //[Route("Kitap")]
        [Route("taylan-kumeli-kitaplari")]
        public async Task<IActionResult> Index()
        {
            GetAllActiveBlogQueryRequest request = new();
            GetAllActiveBlogQueryResponse response = await _mediator.Send(request);

            int LangID = _operationService.SessionLangId();
            if (LangID == 2)
            {
                TempData["Title"] = "Books";
            }
            else
            {
                TempData["Title"] = "Kitaplar";
            }

            if (response.Books == null)
                return NotFound();

            return View(response.Books);
        }

        [Route("book/{id}")]
        public async Task<IActionResult> Edit(GetBookDetailQueryRequest request)
        {
            GetBookDetailQueryResponse response = await _mediator.Send(request);

            int LangID = _operationService.SessionLangId();
            if (LangID == 2)
            {
                TempData["Title"] = "Books";
            }
            else
            {
                TempData["Title"] = "Kitaplar";
            }

            if (response.Book != null)
            {
                TempData["MetaKey"] = response.Book.Action;
                TempData["MetaDescription"] = response.Book.BookName;
                TempData["MetaTitle"] = response.Book.BookName;

                if (TempData["orderNo"] is string && TempData["parentID"] is int && TempData["internalID"] is int)
                {
                    HttpContext.Session.SetString(SessionOrderNo, (string)TempData["orderNo"]);
                    HttpContext.Session.SetInt32(SessionParentID, (int)TempData["parentID"]);
                    HttpContext.Session.SetInt32(SessionInternalID, (int)TempData["internalID"]);
                }
                else
                {
                    TempData["orderNo"] = response.Book.NavigationOrderNo;
                    TempData["parentID"] = response.Book.NavigationId;
                    TempData["internalID"] = response.Book.Id;
                }

                return View(response.Book);
            }
            else
            {
                return NotFound();
            }

        }

        public IActionResult Preview(string id, string orderNo, int parentID, int internalID)
        {
            TempData["parentID"] = parentID;
            TempData["orderNo"] = orderNo;
            TempData["internalID"] = internalID;
            return RedirectToAction("Edit", "UIBook", new { id });
        }
    }
}
