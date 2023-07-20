using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace MVCBlogApp.UI.Controllers
{
    public class UIArticleController : Controller
    {
        private readonly IMediator _mediator;

        public UIArticleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("tr/{id}")]
        public IActionResult Index(string id)
        {
            //if (id != null)
            //{
            //    const string cacheKey = CacheKey.ArticleKey;

            //    var navigationsDB = _navigationRepository.GetList(x => x.IsActive == true && x.IsAdmin == false).OrderBy(x => x.ParentID).ThenBy(x => x.OrderNo).ThenBy(x => x.ID).ToList();
            //    var art = _dataContext.Article.SingleOrDefault(x => x.UrlRoot == id);
            //    int keys = art.ID;

            //    TempData["MetaKey"] = art.MetaKey;
            //    TempData["MetaDescription"] = art.MetaDescription;
            //    TempData["MetaTitle"] = art.MetaTitle;


            //    if (TempData["orderNo"] is string && TempData["parentID"] is int)
            //    {
            //        this.session.SetString(SessionOrderNo, (string)TempData["orderNo"]);
            //        this.session.SetInt32(SessionParentID, (int)TempData["parentID"]);
            //        this.session.SetInt32(SessionInternalID, (int)TempData["internalID"]);
            //    }
            //    else
            //    {
            //        TempData["orderNo"] = navigationsDB.Find(x => x.ID == art.NavigationID).OrderNo;
            //        TempData["parentID"] = art.NavigationID;
            //        TempData["internalID"] = art.ID;
            //    }


            //    if (_memoryCache.TryGetValue(cacheKey, out ArticleList))
            //    {
            //        return View(ArticleList);
            //    }
            //    else
            //    {

            //        ArticleList = ArticleList = _articleRepository.GetDetailArticleByID(1, keys);

            //        if (ArticleList == null)
            //            return NotFound();

            //        _memoryCache.Set(cacheKey, ArticleList, new MemoryCacheEntryOptions
            //        {
            //            AbsoluteExpiration = DateTime.Now.AddDays(1),
            //            Priority = CacheItemPriority.Normal
            //        });

            //        return View(ArticleList);
            //    }

            //}
            //else
                return NotFound();

        }
    }
}
