using Microsoft.EntityFrameworkCore;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Features.Queries.UIArticle.UIArticleIndex;
using MVCBlogApp.Application.Features.Queries.UIArticle.UILeftNavigation;
using MVCBlogApp.Application.Repositories.Article;
using MVCBlogApp.Application.Repositories.Blog;
using MVCBlogApp.Application.Repositories.Book;
using MVCBlogApp.Application.Repositories.Navigation;
using MVCBlogApp.Application.Repositories.Status;
using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Persistence.Services
{
    public class UIOtherService : IUIOtherService
    {
        private readonly IOperationService _operationService;
        private readonly IStatusReadRepository _statusReadRepository;
        private readonly IArticleReadRepository _articleReadRepository;
        private readonly IBlogReadRepository _blogReadRepository;
        private readonly INavigationReadRepository _navigationReadRepository;
        private readonly IBookReadRepository _bookReadRepository;

        public UIOtherService(
            IOperationService operationService,
            IStatusReadRepository statusReadRepository,
            IArticleReadRepository articleReadRepository,
            IBlogReadRepository blogReadRepository,
            INavigationReadRepository navigationReadRepository,
            IBookReadRepository bookReadRepository
            )
        {
            _operationService = operationService;
            _statusReadRepository = statusReadRepository;
            _articleReadRepository = articleReadRepository;
            _blogReadRepository = blogReadRepository;
            _navigationReadRepository = navigationReadRepository;
            _bookReadRepository = bookReadRepository;
        }

        
        #region Article

        public async Task<UILeftNavigationQueryResponse> UILeftNavigationAsync(UILeftNavigationQueryRequest request)
        {
            int langId = _operationService.SessionLangId();
            int statusActiveId = await _statusReadRepository.GetWhere(x => x.StatusName == "Aktif").Select(x => x.Id).FirstAsync();

            var navigationsDB = await _navigationReadRepository.GetWhere(x => x.IsActive == true && x.IsAdmin == false).OrderBy(x => x.ParentId).ThenBy(x => x.OrderNo).ThenBy(x => x.Id).ToListAsync();
            var articles = await _articleReadRepository.GetWhere(x => x.StatusId == statusActiveId && x.IsMenu == true && x.NavigationId != null).OrderBy(x => x.Orders).ToListAsync();
            var blogs = await _blogReadRepository.GetWhere(x => x.StatusId == statusActiveId && x.IsMenu == true && x.NavigationId != null && x.BlogTypeId == 2).OrderBy(x => x.Orders).ToListAsync();
            var books = await _bookReadRepository.GetWhere(x => x.StatusId == statusActiveId && x.NavigationId != null).OrderBy(x => x.Orders).ToListAsync();

            if (request.orderNo != null && request.parentID != null)
            {
                //Articles
                var navigations = await _articleReadRepository.GetWhere(x => x.IsMenu == true && x.StatusId == statusActiveId && x.IsComponent == true && x.NavigationId == request.parentID).OrderBy(x => x.Orders)
                    .Select(y => new VM_Navigation
                    {
                        Id = y.Id,
                        NavigationName = y.Title,
                        UrlRoot = y.UrlRoot,
                        Action = y.Action,
                        Controller = y.Controller,
                        CreateDate = y.CreateDate,
                        FontAwesomeIcon = y.FontAwesomeIcon,
                        MetaKey = y.MetaKey,
                        MetaTitle = y.MetaTitle,
                        ParentId = (int)y.NavigationId
                    }).ToListAsync();

                ////Blog
                //navigations.AddRange(await _blogReadRepository.GetWhere(x => x.NavigationId != null && x.IsMenu != null && x.StatusId == statusActiveId && x.BlogTypeId == 2 && x.IsComponent == true)
                //    .Select(y => new VM_Navigation
                //    {
                //        Id = y.Id,
                //        NavigationName = y.Title,
                //        CreateDate = y.CreateDate,
                //        MetaKey = y.MetaKey,
                //        MetaTitle = y.MetaTitle,
                //        ParentId = (int)y.NavigationId,
                //        UrlRoot = y.UrlRoot,
                //        OrderNo = navigationsDB.Find(x => x.Id == y.NavigationId).OrderNo
                //    }).ToListAsync());

                ////Book
                //navigations.AddRange(await _bookReadRepository.GetWhere(x => x.StatusId == statusActiveId && x.NavigationId != null && x.Orders != null).OrderBy(x => x.Orders)
                //    .Select(y => new VM_Navigation
                //    {
                //        CreateDate = y.CreateDate,
                //        Id = y.Id,
                //        NavigationName = y.BookName,
                //        ParentId = (int)y.NavigationId,
                //        UrlRoot = y.UrlRoot,
                //        Action = y.Action,
                //        Controller = y.Controller,
                //        OrderNo = navigationsDB.Find(x => x.Id == y.NavigationId).OrderNo
                //    }).ToListAsync());

                var mainMenu = navigationsDB.Find(x => x.Id == request.parentID && x.OrderNo == request.orderNo);
                var model = new List<VM_Navigation>();


                if (mainMenu.ParentId == 0)
                {
                    model = navigations.Where(x => x.ParentId == request.parentID)
                        .Select(y => new VM_Navigation
                        {
                            Action = y.Action,
                            Controller = y.Controller,
                            MetaKey = y.MetaKey,
                            MetaTitle = y.MetaTitle,
                            NavigationName = y.NavigationName,
                            UrlRoot = y.UrlRoot,
                            ParentId = y.ParentId,
                            OrderNo = y.OrderNo,
                            Id = y.Id
                        }).ToList();
                }
                else if (navigationsDB.Find(x => x.Id == request.parentID).IsHeader == true)
                {
                    model = navigations.Where(x => x.ParentId == request.parentID)
                        .Select(y => new VM_Navigation
                        {
                            Action = y.Action,
                            Controller = y.Controller,
                            MetaKey = y.MetaKey,
                            MetaTitle = y.MetaTitle,
                            NavigationName = y.NavigationName,
                            UrlRoot = y.UrlRoot,
                            ParentId = y.ParentId,
                            OrderNo = y.OrderNo,
                            Id = y.Id
                        }).ToList();
                }
                else if (request.orderNo.StartsWith('2') == true)
                {
                    navigationsDB = await _navigationReadRepository
                        .GetWhere(x => x.IsAdmin == false && x.IsActive == true && x.OrderNo.StartsWith(request.orderNo[0]) && x.ParentId == request.parentID && x.IsHeader == null && x.IsSubHeader == null)
                        .OrderBy(x => x.ParentId)
                        .ThenBy(x => x.OrderNo)
                        .ThenBy(x => x.Id)
                        .ToListAsync();

                    model = navigationsDB.Where(x => x.IsAdmin == false).Select(y => new VM_Navigation
                    {
                        Action = y.Action,
                        Controller = y.Controller,
                        FontAwesomeIcon = y.FontAwesomeIcon,
                        Id = y.Id,
                        IsActive = y.IsActive,
                        IsHeader = y.IsHeader,
                        IsSubHeader = y.IsSubHeader,
                        LangId = y.LangId,
                        MetaKey = y.MetaKey,
                        MetaTitle = y.MetaTitle,
                        NavigationName = y.NavigationName,
                        OrderNo = y.OrderNo,
                        ParentId = y.ParentId,
                        UrlRoot = y.UrlRoot,
                        CreateDate = y.CreateDate,
                        MenuCount = articles.Where(x => x.NavigationId == y.Id).Count() + blogs.Where(x => x.NavigationId == y.Id).Count() + books.Where(x => x.NavigationId == y.Id).Count(),
                        HeaderCount = navigationsDB.Where(x => x.ParentId == y.Id && x.IsHeader == true).Count(),
                        SubHeaderCount = navigationsDB.Where(x => x.ParentId == y.Id && x.IsSubHeader == true).Count()
                    }).ToList();
                }
                return new()
                {
                    LeftNavigations = model
                };
            }
            else
            {
                return new()
                {
                    LeftNavigations = null
                };
            }
        }

        public async Task<UIArticleIndexQueryResponse> UIArticleIndexAsync(UIArticleIndexQueryRequest request)
        {
            VM_Article? vM_Article = await _articleReadRepository.GetWhere(x => x.UrlRoot == request.id)
                .Join(_navigationReadRepository.GetAll(), art => art.NavigationId, nav => nav.Id, (art, nav) => new { art, nav })
                .Select(x => new VM_Article
                {
                    Id = x.art.Id,
                    MetaDescription = x.art.MetaDescription,
                    MetaKey = x.art.MetaKey,
                    MetaTitle = x.art.MetaTitle,
                    NavigationId = x.art.NavigationId,
                    OrderNo = x.nav.OrderNo
                }).FirstOrDefaultAsync();

            return new()
            {
                Article = vM_Article
            };
        }



        #endregion
    }
}
