using MediatR;
using Microsoft.AspNetCore.Mvc;
using MVCBlogApp.Application.Features.Queries.UIArticle.UIArticleIndex;

namespace MVCBlogApp.UI.Controllers
{
    public class UIArticleController : Controller
    {
        public const string SessionOrderNo = "_OrderNo";
        public const string SessionParentID = "_ParentID";
        public const string SessionInternalID = "_InternalID";

        private readonly IMediator _mediator;

        public UIArticleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("/{id}")]
        public async Task<IActionResult> Index(UIArticleIndexQueryRequest request)
        {
            UIArticleIndexQueryResponse response = await _mediator.Send(request);
            if (response.Article != null)
            {


                TempData["MetaKey"] = response.Article.MetaKey;
                TempData["MetaDescription"] = response.Article.MetaDescription;
                TempData["MetaTitle"] = response.Article.MetaTitle;


                if (TempData["orderNo"] is string && TempData["parentID"] is int)
                {
                    HttpContext.Session.SetString(SessionOrderNo, (string)TempData["orderNo"]);
                    HttpContext.Session.SetInt32(SessionParentID, (int)TempData["parentID"]);
                    HttpContext.Session.SetInt32(SessionInternalID, (int)TempData["internalID"]);
                }
                else
                {
                    TempData["orderNo"] = response.Article.OrderNo;
                    TempData["parentID"] = response.Article.NavigationId;
                    TempData["internalID"] = response.Article.Id;
                }

                return View(response.Article);

            }
            else
            {
                return NotFound();
            }
        }
    }
}
