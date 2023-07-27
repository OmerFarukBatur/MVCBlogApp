using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Features.Commands.ConsultancyForms.ConsultancyFormsCreate;
using MVCBlogApp.Application.Features.Commands.Contact.ContactCreate;
using MVCBlogApp.Application.Features.Commands.Test.BMICalculateCreate;
using MVCBlogApp.Application.Features.Commands.Test.OptimumCalculateCreate;
using MVCBlogApp.Application.Features.Queries.IUWorkShop.GetWhereWorkShop;
using MVCBlogApp.Application.Features.Queries.Test.BMICalculate;
using MVCBlogApp.Application.Features.Queries.Test.OptimumCalculate;
using MVCBlogApp.Application.Features.Queries.UIArticle.UIArticleIndex;
using MVCBlogApp.Application.Features.Queries.UIArticle.UILeftNavigation;
using MVCBlogApp.Application.Features.Queries.UIBlog.BasariHikayeleriPartialView;
using MVCBlogApp.Application.Features.Queries.UIBlog.BlogCategoryIndex;
using MVCBlogApp.Application.Features.Queries.UIBlog.SimilarSubjects;
using MVCBlogApp.Application.Features.Queries.UIBlog.TagCloudAndSocialMedia;
using MVCBlogApp.Application.Features.Queries.UIBlog.UIBlogPartialView;
using MVCBlogApp.Application.Features.Queries.UIBlog.YemekTarifleriPartialView;
using MVCBlogApp.Application.Features.Queries.UIBook.GetAllActiveBooks;
using MVCBlogApp.Application.Features.Queries.UIBook.GetBookDetail;
using MVCBlogApp.Application.Features.Queries.UIPress.MedyaYansimalariPartialView;
using MVCBlogApp.Application.Helpers;
using MVCBlogApp.Application.Repositories.Article;
using MVCBlogApp.Application.Repositories.Blog;
using MVCBlogApp.Application.Repositories.BlogCategory;
using MVCBlogApp.Application.Repositories.BlogType;
using MVCBlogApp.Application.Repositories.Book;
using MVCBlogApp.Application.Repositories.CalcBMI;
using MVCBlogApp.Application.Repositories.CalcOptimum;
using MVCBlogApp.Application.Repositories.ConsultancyForm;
using MVCBlogApp.Application.Repositories.ConsultancyFormType;
using MVCBlogApp.Application.Repositories.Contact;
using MVCBlogApp.Application.Repositories.ContactCategory;
using MVCBlogApp.Application.Repositories.FixBMI;
using MVCBlogApp.Application.Repositories.FixOptimum;
using MVCBlogApp.Application.Repositories.Genders;
using MVCBlogApp.Application.Repositories.Navigation;
using MVCBlogApp.Application.Repositories.NewsPaper;
using MVCBlogApp.Application.Repositories.Press;
using MVCBlogApp.Application.Repositories.PressType;
using MVCBlogApp.Application.Repositories.ResultBMI;
using MVCBlogApp.Application.Repositories.ResultOptimum;
using MVCBlogApp.Application.Repositories.Status;
using MVCBlogApp.Application.Repositories.Workshop;
using MVCBlogApp.Application.Repositories.WorkshopCategory;
using MVCBlogApp.Application.Repositories.WorkshopEducation;
using MVCBlogApp.Application.Repositories.WorkshopType;
using MVCBlogApp.Application.Repositories.X_BlogCategory;
using MVCBlogApp.Application.ViewModels;
using MVCBlogApp.Domain.Entities;

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
        private readonly IBlogTypeReadRepository _blogTypeReadRepository;
        private readonly IBlogCategoryReadRepository _blogCategoryReadRepository;
        private readonly IX_BlogCategoryReadRepository _x_BlogCategoryReadRepository;
        private readonly IConsultancyFormWriteRepository _consultancyFormWriteRepository;
        private readonly IMailService _mailService;
        private readonly IConsultancyFormTypeReadRepository _consultancyFormTypeReadRepository;
        private readonly IContactCategoryReadRepository _contactCategoryReadRepository;
        private readonly IContactWriteRepository _contactWriteRepository;
        private readonly IPressReadRepository _pressReadRepository;
        private readonly IPressTypeReadRepository _pressTypeReadRepository;
        private readonly INewsPaperReadRepository _newsPaperReadRepository;
        private readonly IFixBMIReadRepository _fixBMIReadRepository;
        private readonly IResultBMIReadRepository _resultBMIReadRepository;
        private readonly ICalcBMIWriteRepository _calcBMIWriteRepository;
        private readonly IGendersReadRepository _gendersReadRepository;
        private readonly IFixOptimumReadRepository _fixOptimumReadRepository;
        private readonly IResultOptimumReadRepository _resultOptimumReadRepository;
        private readonly ICalcOptimumWriteRepository _calcOptimumWriteRepository;
        private readonly IWorkshopReadRepository _workshopReadRepository;
        private readonly IWorkshopEducationReadRepository _workshopEducationReadRepository;
        private readonly IWorkshopTypeReadRepository _workshopTypeReadRepository;
        private readonly IWorkshopCategoryReadRepository _workshopCategoryReadRepository;

        public UIOtherService(
            IOperationService operationService,
            IStatusReadRepository statusReadRepository,
            IArticleReadRepository articleReadRepository,
            IBlogReadRepository blogReadRepository,
            INavigationReadRepository navigationReadRepository,
            IBookReadRepository bookReadRepository,
            IBlogTypeReadRepository blogTypeReadRepository,
            IBlogCategoryReadRepository blogCategoryReadRepository,
            IX_BlogCategoryReadRepository x_BlogCategoryReadRepository,
            IConsultancyFormWriteRepository consultancyFormWriteRepository,
            IMailService mailService,
            IConsultancyFormTypeReadRepository consultancyFormTypeReadRepository,
            IContactCategoryReadRepository contactCategoryReadRepository,
            IContactWriteRepository contactWriteRepository,
            IPressReadRepository pressReadRepository,
            IPressTypeReadRepository pressTypeReadRepository,
            INewsPaperReadRepository newsPaperReadRepository,
            IFixBMIReadRepository fixBMIReadRepository,
            IResultBMIReadRepository resultBMIReadRepository,
            ICalcBMIWriteRepository calcBMIWriteRepository,
            IGendersReadRepository gendersReadRepository,
            IFixOptimumReadRepository fixOptimumReadRepository,
            IResultOptimumReadRepository resultOptimumReadRepository,
            ICalcOptimumWriteRepository calcOptimumWriteRepository,
            IWorkshopReadRepository workshopReadRepository,
            IWorkshopEducationReadRepository workshopEducationReadRepository,
            IWorkshopTypeReadRepository workshopTypeReadRepository,
            IWorkshopCategoryReadRepository workshopCategoryReadRepository)
        {
            _operationService = operationService;
            _statusReadRepository = statusReadRepository;
            _articleReadRepository = articleReadRepository;
            _blogReadRepository = blogReadRepository;
            _navigationReadRepository = navigationReadRepository;
            _bookReadRepository = bookReadRepository;
            _blogTypeReadRepository = blogTypeReadRepository;
            _blogCategoryReadRepository = blogCategoryReadRepository;
            _x_BlogCategoryReadRepository = x_BlogCategoryReadRepository;
            _consultancyFormWriteRepository = consultancyFormWriteRepository;
            _mailService = mailService;
            _consultancyFormTypeReadRepository = consultancyFormTypeReadRepository;
            _contactCategoryReadRepository = contactCategoryReadRepository;
            _contactWriteRepository = contactWriteRepository;
            _pressReadRepository = pressReadRepository;
            _pressTypeReadRepository = pressTypeReadRepository;
            _newsPaperReadRepository = newsPaperReadRepository;
            _fixBMIReadRepository = fixBMIReadRepository;
            _resultBMIReadRepository = resultBMIReadRepository;
            _calcBMIWriteRepository = calcBMIWriteRepository;
            _gendersReadRepository = gendersReadRepository;
            _fixOptimumReadRepository = fixOptimumReadRepository;
            _resultOptimumReadRepository = resultOptimumReadRepository;
            _calcOptimumWriteRepository = calcOptimumWriteRepository;
            _workshopReadRepository = workshopReadRepository;
            _workshopEducationReadRepository = workshopEducationReadRepository;
            _workshopTypeReadRepository = workshopTypeReadRepository;
            _workshopCategoryReadRepository = workshopCategoryReadRepository;
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
                var navigations = await _articleReadRepository
                    .GetWhere(x => x.IsMenu == true && x.StatusId == statusActiveId && x.IsComponent == true && x.NavigationId == request.parentID).OrderBy(x => x.Orders)
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
                        ParentId = y.NavigationId
                    }).ToListAsync();

                //Blog
                navigations.AddRange(await _blogReadRepository
                    .GetWhere(x => x.NavigationId != null && x.IsMenu != null && x.StatusId == statusActiveId && x.BlogTypeId == 2 && x.IsComponent == true)
                    .Join(_navigationReadRepository.GetAll(), blog => blog.NavigationId, nav => nav.Id, (blog, nav) => new { blog, nav })
                    .Select(y => new VM_Navigation
                    {
                        Id = y.blog.Id,
                        NavigationName = y.blog.Title,
                        CreateDate = y.blog.CreateDate,
                        MetaKey = y.blog.MetaKey,
                        MetaTitle = y.blog.MetaTitle,
                        ParentId = y.blog.NavigationId,
                        UrlRoot = y.blog.UrlRoot,
                        OrderNo = y.nav.OrderNo
                    }).ToListAsync());

                //Book
                navigations.AddRange(await _bookReadRepository
                    .GetWhere(x => x.StatusId == statusActiveId && x.NavigationId != null && x.Orders != null).OrderBy(x => x.Orders)
                    .Join(_navigationReadRepository.GetAll(), book => book.NavigationId, nav => nav.Id, (book, nav) => new { book, nav })
                    .Select(y => new VM_Navigation
                    {
                        CreateDate = y.book.CreateDate,
                        Id = y.book.Id,
                        NavigationName = y.book.BookName,
                        ParentId = y.book.NavigationId,
                        UrlRoot = y.book.UrlRoot,
                        Action = y.book.Action,
                        Controller = y.book.Controller,
                        OrderNo = y.nav.OrderNo
                    }).ToListAsync());

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
                        .GetWhere(x => x.IsAdmin == false && x.IsActive == true && x.ParentId == request.parentID && x.IsHeader == null && x.IsSubHeader == null)
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
                    OrderNo = x.nav.OrderNo,
                    Title = x.art.Title,
                    Description = x.art.Description
                }).FirstOrDefaultAsync();

            return new()
            {
                Article = vM_Article
            };
        }

        #endregion

        #region Blog

        public async Task<UIBlogPartialViewQueryResponse> UIBlogPartialViewAsync(UIBlogPartialViewQueryRequest request)
        {
            int langId = _operationService.SessionLangId();
            int statusId = await _statusReadRepository.GetWhere(x => x.StatusName == "Aktif").Select(x => x.Id).FirstAsync();

            var blog = _blogReadRepository.GetWhere(x => x.BlogTypeId == 1 && x.LangId == langId && x.StatusId == statusId)
                .Join(_blogTypeReadRepository.GetAll(), bl => bl.BlogTypeId, bType => bType.Id, (bl, bType) => new { bl, bType })
                .OrderByDescending(s => s.bl.Id)
                .GetPaged(request.page, 4);

            PagedResult<VM_Blog> result = new()
            {
                CurrentPage = blog.CurrentPage,
                PageCount = blog.PageCount,
                PageSize = blog.PageSize,
                RowCount = blog.RowCount,
                Results = blog.Results.Select(s => new VM_Blog()
                {
                    Id = s.bl.Id,
                    MetaTitle = s.bl.MetaTitle,
                    MetaKey = s.bl.MetaKey,
                    MetaDescription = s.bl.MetaDescription,
                    UrlRoot = s.bl.UrlRoot,
                    Title = s.bl.Title,
                    SubTitle = s.bl.SubTitle,
                    Contents = s.bl.Contents,
                    CoverImgUrl = s.bl.CoverImgUrl,
                    BlogTypeId = s.bl.BlogTypeId,
                    BlogTypeName = s.bType.TypeName,
                    IsMainPage = s.bl.IsMainPage,
                    Orders = s.bl.Orders,
                    NavigationId = s.bl.NavigationId,
                    IsMenu = s.bl.IsMenu,
                    IsComponent = s.bl.IsComponent,
                    Action = s.bl.Action,
                    Controller = s.bl.Controller,
                    BlogCategoryId = s.bl.BlogCategoryId,
                    CreateDate = s.bl.CreateDate,
                    CreateUserId = s.bl.CreateUserId,
                    LangId = s.bl.LangId,
                    StatusId = s.bl.StatusId,
                    UpdateDate = s.bl.UpdateDate,
                    UpdateUserId = s.bl.UpdateUserId
                }).ToList()
            };

            return new()
            {
                Result = result
            };
        }

        public async Task<TagCloudAndSocialMediaQueryResponse> TagCloudAndSocialMediaAsync(TagCloudAndSocialMediaQueryRequest request)
        {
            List<int?> catIDs = await _x_BlogCategoryReadRepository.GetWhere(x => x.BlogId == request.id).Select(x => x.BlogCategoryId).ToListAsync();

            if (catIDs != null)
            {
                List<VM_BlogCategory> tags = await _blogCategoryReadRepository.GetWhere(x => catIDs.Contains(x.Id))
                    .Select(x => new VM_BlogCategory
                    {
                        ID = x.Id,
                        CategoryDescription = x.CategoryDescription,
                        CategoryName = x.CategoryName,
                        LangID = (int)x.LangId,
                        StatusID = (int)x.StatusId
                    }).ToListAsync();

                return new()
                {
                    BlogCategories = tags
                };
            }
            else
            {
                return new()
                {
                    BlogCategories = null
                };
            }
        }

        public async Task<SimilarSubjectsQueryResponse> SimilarSubjectsAsync(SimilarSubjectsQueryRequest request)
        {
            int LangID = _operationService.SessionLangId();
            int activeStatusId = await _statusReadRepository.GetWhere(x => x.StatusName == "Aktif").Select(x => x.Id).FirstOrDefaultAsync();

            List<int?> similarBlogIDs = null;

            List<int?> catIDs = await _x_BlogCategoryReadRepository.GetWhere(x => x.BlogId == request.blogID).Select(x => x.BlogCategoryId).ToListAsync();

            if (catIDs != null)
            {
                similarBlogIDs = await _x_BlogCategoryReadRepository.GetWhere(x => catIDs.Contains(x.BlogCategoryId) && x.BlogId != request.blogID)
                                .Select(x => x.BlogId).ToListAsync();
            }

            if (similarBlogIDs != null)
            {
                List<VM_Blog> vM_blogs = await _blogReadRepository.GetWhere(x => similarBlogIDs.Contains(x.Id) && x.LangId == LangID && x.StatusId == activeStatusId)
                    .Take(4).Select(y => new VM_Blog
                    {
                        Id = y.Id,
                        BlogCategoryId = y.BlogCategoryId,
                        Contents = y.Contents,
                        CoverImgUrl = y.CoverImgUrl,
                        CreateDate = y.CreateDate,
                        CreateUserId = y.CreateUserId,
                        LangId = y.LangId,
                        MetaDescription = y.MetaDescription,
                        MetaKey = y.MetaKey,
                        MetaTitle = y.MetaTitle,
                        UrlRoot = y.UrlRoot,
                        StatusId = y.StatusId,
                        SubTitle = y.SubTitle.Length > 50 ? y.SubTitle.Substring(0, 50) : y.SubTitle,
                        Title = y.Title,
                        UpdateDate = y.UpdateDate,
                        UpdateUserId = y.UpdateUserId,
                        Action = y.Action,
                        BlogTypeId = y.BlogTypeId,
                        Controller = y.Controller,
                        IsComponent = y.IsComponent,
                        IsMainPage = y.IsMainPage,
                        IsMenu = y.IsMenu,
                        NavigationId = y.NavigationId,
                        Orders = y.Orders
                    }).ToListAsync();

                return new()
                {
                    Blogs = vM_blogs
                };
            }
            else
            {
                return new()
                {
                    Blogs = null
                };
            }
        }

        public async Task<BlogCategoryIndexQueryResponse> BlogCategoryIndexAsync(BlogCategoryIndexQueryRequest request)
        {
            int catId = await _blogCategoryReadRepository.GetWhere(x => x.CategoryName.Trim() == request.catName.Replace("-", " ")).Select(x => x.Id).FirstOrDefaultAsync();

            List<int?> blogIDs = await _x_BlogCategoryReadRepository.GetWhere(x => x.BlogCategoryId == catId).Select(x => x.BlogId).ToListAsync();

            if (blogIDs != null)
            {
                List<VM_Blog> blogs = await _blogReadRepository.GetWhere(x => blogIDs.Contains(x.Id)).Select(y => new VM_Blog
                {
                    Action = y.Action,
                    BlogCategoryId = y.BlogCategoryId,
                    BlogTypeId = y.BlogTypeId,
                    Contents = y.Contents,
                    Controller = y.Controller,
                    CoverImgUrl = y.CoverImgUrl,
                    CreateDate = y.CreateDate,
                    CreateUserId = y.CreateUserId,
                    Id = y.Id,
                    IsComponent = y.IsComponent,
                    IsMainPage = y.IsMainPage,
                    IsMenu = y.IsMenu,
                    LangId = y.LangId,
                    MetaDescription = y.MetaDescription,
                    MetaKey = y.MetaKey,
                    MetaTitle = y.MetaTitle,
                    NavigationId = y.NavigationId,
                    Orders = y.Orders,
                    StatusId = y.StatusId,
                    SubTitle = y.SubTitle,
                    Title = y.Title,
                    UpdateDate = y.UpdateDate,
                    UpdateUserId = y.UpdateUserId,
                    UrlRoot = y.UrlRoot
                }).ToListAsync();

                return new()
                {
                    Blogs = blogs
                };
            }
            else
            {
                return new()
                {
                    Blogs = null
                };
            }
        }

        public async Task<BasariHikayeleriPartialViewQueryResponse> BasariHikayeleriPartialViewAsync(BasariHikayeleriPartialViewQueryRequest request)
        {
            int langId = _operationService.SessionLangId();
            int statusId = await _statusReadRepository.GetWhere(x => x.StatusName == "Aktif").Select(x => x.Id).FirstAsync();

            var blog = _blogReadRepository.GetWhere(x => x.BlogTypeId == 2 && x.LangId == langId && x.StatusId == statusId)
                .Join(_blogTypeReadRepository.GetAll(), bl => bl.BlogTypeId, bType => bType.Id, (bl, bType) => new { bl, bType })
                .OrderByDescending(s => s.bl.Id)
                .GetPaged(request.page, 4);

            PagedResult<VM_Blog> result = new()
            {
                CurrentPage = blog.CurrentPage,
                PageCount = blog.PageCount,
                PageSize = blog.PageSize,
                RowCount = blog.RowCount,
                Results = blog.Results.Select(s => new VM_Blog()
                {
                    Id = s.bl.Id,
                    MetaTitle = s.bl.MetaTitle,
                    MetaKey = s.bl.MetaKey,
                    MetaDescription = s.bl.MetaDescription,
                    UrlRoot = s.bl.UrlRoot,
                    Title = s.bl.Title,
                    SubTitle = s.bl.SubTitle,
                    Contents = s.bl.Contents,
                    CoverImgUrl = s.bl.CoverImgUrl,
                    BlogTypeId = s.bl.BlogTypeId,
                    BlogTypeName = s.bType.TypeName,
                    IsMainPage = s.bl.IsMainPage,
                    Orders = s.bl.Orders,
                    NavigationId = s.bl.NavigationId,
                    IsMenu = s.bl.IsMenu,
                    IsComponent = s.bl.IsComponent,
                    Action = s.bl.Action,
                    Controller = s.bl.Controller,
                    BlogCategoryId = s.bl.BlogCategoryId,
                    CreateDate = s.bl.CreateDate,
                    CreateUserId = s.bl.CreateUserId,
                    LangId = s.bl.LangId,
                    StatusId = s.bl.StatusId,
                    UpdateDate = s.bl.UpdateDate,
                    UpdateUserId = s.bl.UpdateUserId
                }).ToList()
            };

            return new()
            {
                Result = result
            };
        }

        public async Task<YemekTarifleriPartialViewQueryResponse> YemekTarifleriPartialViewAsync(YemekTarifleriPartialViewQueryRequest request)
        {
            int langId = _operationService.SessionLangId();
            int statusId = await _statusReadRepository.GetWhere(x => x.StatusName == "Aktif").Select(x => x.Id).FirstAsync();

            var blog = _blogReadRepository.GetWhere(x => x.BlogTypeId == 3 && x.LangId == langId && x.StatusId == statusId)
                .Join(_blogTypeReadRepository.GetAll(), bl => bl.BlogTypeId, bType => bType.Id, (bl, bType) => new { bl, bType })
                .OrderByDescending(s => s.bl.Id)
                .GetPaged(request.page, 4);

            PagedResult<VM_Blog> result = new()
            {
                CurrentPage = blog.CurrentPage,
                PageCount = blog.PageCount,
                PageSize = blog.PageSize,
                RowCount = blog.RowCount,
                Results = blog.Results.Select(s => new VM_Blog()
                {
                    Id = s.bl.Id,
                    MetaTitle = s.bl.MetaTitle,
                    MetaKey = s.bl.MetaKey,
                    MetaDescription = s.bl.MetaDescription,
                    UrlRoot = s.bl.UrlRoot,
                    Title = s.bl.Title,
                    SubTitle = s.bl.SubTitle,
                    Contents = s.bl.Contents,
                    CoverImgUrl = s.bl.CoverImgUrl,
                    BlogTypeId = s.bl.BlogTypeId,
                    BlogTypeName = s.bType.TypeName,
                    IsMainPage = s.bl.IsMainPage,
                    Orders = s.bl.Orders,
                    NavigationId = s.bl.NavigationId,
                    IsMenu = s.bl.IsMenu,
                    IsComponent = s.bl.IsComponent,
                    Action = s.bl.Action,
                    Controller = s.bl.Controller,
                    BlogCategoryId = s.bl.BlogCategoryId,
                    CreateDate = s.bl.CreateDate,
                    CreateUserId = s.bl.CreateUserId,
                    LangId = s.bl.LangId,
                    StatusId = s.bl.StatusId,
                    UpdateDate = s.bl.UpdateDate,
                    UpdateUserId = s.bl.UpdateUserId
                }).ToList()
            };

            return new()
            {
                Result = result
            };
        }

        #endregion

        #region Book

        public async Task<GetAllActiveBlogQueryResponse> GetAllActiveBooksAsync()
        {
            int langId = _operationService.SessionLangId();
            int statusId = await _statusReadRepository.GetWhere(x => x.StatusName == "Aktif").Select(x => x.Id).FirstAsync();

            List<VM_Book> vM_Books = await _bookReadRepository.GetWhere(x => x.LangId == langId && x.StatusId == statusId)
                .Select(s => new VM_Book
                {
                    Id = s.Id,
                    BookName = s.BookName,
                    PublicationYear = s.PublicationYear,
                    UrlRoot = s.UrlRoot,
                    Content = s.Content,
                    ImageUrl = s.ImageUrl,
                    CreateUserId = s.CreateUserId,
                    CreateDate = s.CreateDate,
                    StatusId = s.StatusId,
                    IsMainPage = s.IsMainPage,
                    Action = s.Action,
                    Controller = s.Controller
                }).ToListAsync();

            return new()
            {
                Books = vM_Books
            };
        }

        public async Task<GetBookDetailQueryResponse> GetBookDetailAsync(GetBookDetailQueryRequest request)
        {
            int langId = _operationService.SessionLangId();
            int statusId = await _statusReadRepository.GetWhere(x => x.StatusName == "Aktif").Select(x => x.Id).FirstAsync();

            VM_Book? vM_Book = await _bookReadRepository.GetWhere(x => x.LangId == langId && x.UrlRoot == request.id)
                .Join(_navigationReadRepository.GetAll(), book => book.NavigationId, nav => nav.Id, (book, nav) => new { book, nav })
                .Select(x => new VM_Book
                {
                    Id = x.book.Id,
                    Action = x.book.Action,
                    NavigationId = x.book.NavigationId,
                    BookName = x.book.BookName,
                    Content = x.book.Content,
                    Controller = x.book.Controller,
                    CreateDate = x.book.CreateDate,
                    CreateUserId = x.book.CreateUserId,
                    ImageUrl = x.book.ImageUrl,
                    IsMainPage = x.book.IsMainPage,
                    LangId = x.book.LangId,
                    MetaDescription = x.book.MetaDescription,
                    MetaKey = x.book.MetaKey,
                    MetaTitle = x.book.MetaTitle,
                    Orders = x.book.Orders,
                    PublicationYear = x.book.PublicationYear,
                    StatusId = x.book.StatusId,
                    UrlRoot = x.book.UrlRoot,
                    NavigationOrderNo = x.nav.OrderNo
                }).FirstOrDefaultAsync();

            if (vM_Book != null)
            {
                return new()
                {
                    Book = vM_Book
                };
            }
            else
            {
                return new()
                {
                    Book = null
                };
            }
        }

        #endregion

        #region ConsultancyForms

        public async Task<ConsultancyFormsCreateCommandResponse> ConsultancyFormsCreateAsync(ConsultancyFormsCreateCommandRequest request)
        {
            int typeId = 0;

            int langId = _operationService.SessionLangId();
            int statusId = await _statusReadRepository.GetWhere(x => x.StatusName == "Aktif").Select(x => x.Id).FirstAsync();

            if (request.id == "bireysel-beslenme-danismanligi-formu" || request.id == "individual-nutrition-counseling-form")
            {
                typeId = 1;


            }
            else if (request.id == "kurumsal-beslenme-danismanligi-formu" || request.id == "corporate-nutrition-consultancy-form")
            {
                typeId = 2;

            }

            else if (request.id == "cocuklar-icin-beslenme-danismanligi-formu" || request.id == "nutrition-counseling-for-children-form")
            {
                typeId = 3;

            }


            ConsultancyForm consultancyForm = new()
            {
                ConsultancyFormTypeId = typeId,
                CreateDate = DateTime.Now,
                Email = request.Email,
                Message = request.Message,
                NameSurname = request.NameSurname,
                Phone = request.Phone,
                StatusId = statusId,
                Subject = request.Subject
            };

            await _consultancyFormWriteRepository.AddAsync(consultancyForm);
            await _consultancyFormWriteRepository.SaveAsync();

            string? typeName = await _consultancyFormTypeReadRepository.GetWhere(x => x.Id == typeId).Select(x => x.ConsultancyFormTypeName).FirstAsync();

            string body = $@"
                    {request.NameSurname} İsimli Danışan yeni bir {request.id.ToLower().Replace("-", " ")} gönderdi. 
                    <br>
                    <br>
                    <b>Yapılan Başvuru:</b> {typeName}
                    <br>
                    <b>Adı Soyadı:</b> {request.NameSurname}
                    <br>
                    <b>Mail Adresi:</b> {request.Email}
                    <br>
                    <b>Telefon Numarası:</b> {request.Phone}
                    <br>
                    <b>Başlık:</b> {request.Subject}
                    <br>
                    <b>İçerik:</b>  <br> {request.Message}
                    ";

            await _mailService.SendMailAsync(
                 "cansu@taylankumeli.com,info@taylankumeli.com,ceren@taylankumeli.com,karahasan.ayse@gmail.com,udavutoglu@yahoo.com",
                 $"Tarafınıza Yeni Bir {request.id.ToLower().Replace("-", " ")} Gönderildi",
                 body,
                 true
                 );

            return new()
            {
                Message = "Kayıt işlemi başarıyla yapılmıştır.",
                State = true
            };
        }

        #endregion

        #region Contact

        public async Task<ContactCreateCommandResponse> ContactCreateAsync(ContactCreateCommandRequest request)
        {
            int langId = _operationService.SessionLangId();
            int statusId = await _statusReadRepository.GetWhere(x => x.StatusName == "Aktif").Select(x => x.Id).FirstAsync();

            Contact contact = new()
            {
                ContactCategoryId = request.ContactCategoryId,
                CreateDate = DateTime.Now,
                Description = request.Description,
                Email = request.Email,
                IsRead = false,
                NameSurname = request.NameSurname,
                Phone = request.Phone,
                StatusId = statusId,
                Subject = request.Subject
            };

            await _contactWriteRepository.AddAsync(contact);
            await _contactWriteRepository.SaveAsync();

            string? ConCatName = await _contactCategoryReadRepository.GetWhere(x => x.Id == request.ContactCategoryId).Select(x => x.ContactCategoryName).FirstOrDefaultAsync();

            string body = $@"
                    {request.NameSurname} İsimli Danışan yeni bir iletişim formu gönderdi. 
                    <br>
                    <br>
                    <b>Adı ve Soyadı:</b> {request.NameSurname}
                    <br>
                    <b>Mail Adresi:</b> {request.Email}
                    <br>
                    <b>Telefon Numarası:</b> {request.Phone}
                    <br>
                    <b>Başlık:</b> {request.Subject}
                    <br>
                    <b>Konu Başlığı:</b> {ConCatName}
                    <br>
                    <b>İçerik:</b>  <br> {request.Description}
                    ";

            await _mailService.SendMailAsync(
                "cansu@taylankumeli.com,info@taylankumeli.com,ceren@taylankumeli.com,karahasan.ayse@gmail.com,udavutoglu@yahoo.com",
                request.Subject + " Mail Başlığı İle Yeni Bir İletişim Formu Gönderildi",
                body,
                true
                );


            return new()
            {
                Message = "Kayıt işlemi başarıyla yapılmıştır.",
                State = true
            };

        }

        #endregion

        #region Press

        public async Task<MedyaYansimalariPartialViewQueryResponse> MedyaYansimalariPartialAsync(MedyaYansimalariPartialViewQueryRequest request)
        {
            int langId = _operationService.SessionLangId();
            int statusId = await _statusReadRepository.GetWhere(x => x.StatusName == "Aktif").Select(x => x.Id).FirstAsync();

            var vM_Presses = _pressReadRepository.GetWhere(x => x.StatusId == statusId && x.LangId == langId)
                .Join(_statusReadRepository.GetAll(), pre => pre.StatusId, st => st.Id, (pre, st) => new { pre, st })
                .Join(_pressTypeReadRepository.GetAll(), pres => pres.pre.PressTypeId, pt => pt.Id, (pres, pt) => new { pres, pt })
                .Join(_newsPaperReadRepository.GetAll(), press => press.pres.pre.NewsPaperId, wp => wp.Id, (press, wp) => new { press, wp })
                .Select(x => new VM_Press
                {
                    Id = x.press.pres.pre.Id,
                    StatusName = x.press.pres.st.StatusName,
                    NewsPaperName = x.wp.NewsPaperName,
                    PressTypeName = x.press.pt.PressTypeName,
                    SubTitle = x.press.pres.pre.SubTitle,
                    Title = x.press.pres.pre.Title,
                    ImageUrl = x.press.pres.pre.ImageUrl,
                    CreateDate = x.press.pres.pre.CreateDate,
                    Description = x.press.pres.pre.Description,
                    LangId = x.press.pres.pre.LangId,
                    MetaDescription = x.press.pres.pre.MetaDescription,
                    MetaKey = x.press.pres.pre.MetaKey,
                    MetaTitle = x.press.pres.pre.MetaTitle,
                    NewsPaperId = x.press.pres.pre.NewsPaperId,
                    PressTypeId = x.press.pres.pre.PressTypeId,
                    StatusId = x.press.pres.pre.StatusId,
                    UrlLink = x.press.pres.pre.UrlLink,
                    UrlRoot = x.press.pres.pre.UrlRoot
                }).OrderByDescending(s => s.Id).GetPaged(request.page, 6);

            return new()
            {
                Result = vM_Presses
            };
        }

        #endregion

        #region BMICalculate

        public async Task<BMICalculateQueryResponse> BMICalculateAsync()
        {
            int langId = _operationService.SessionLangId();

            VM_FixBMI? vM_FixBMI = await _fixBMIReadRepository.GetWhere(x=> x.LangId == langId)
                .Select(x=> new VM_FixBMI
                {
                    Id = x.Id,
                    Description = x.Description,
                    FormId = x.FormId,
                    ImgUrl = x.ImgUrl,
                    StatusId= x.StatusId,
                    LangId = x.LangId,
                    Title = x.Title
                }).FirstOrDefaultAsync();

            return new()
            {
                BMI = new()
                {
                    FixBMI = vM_FixBMI
                }
            };
        }

        public async Task<BMICalculateCreateCommandResponse> BMICalculateCreateAsync(BMICalculateCreateCommandRequest request)
        {
            int langId = _operationService.SessionLangId();

            VM_FixBMI? vM_FixBMI = await _fixBMIReadRepository.GetAll()
                .Select(x => new VM_FixBMI
                {
                    Id = x.Id,
                    Description = x.Description,
                    FormId = x.FormId,
                    ImgUrl = x.ImgUrl,
                    StatusId = x.StatusId,
                    LangId = x.LangId,
                    Title = x.Title
                }).FirstOrDefaultAsync();

            List<VM_ResultBMI>? vM_ResultBMI = await _resultBMIReadRepository.GetAll()
                .Select(x => new VM_ResultBMI
                {
                    Id = x.Id,
                    IntervalDescription = x.IntervalDescription,
                    IntervalMax = x.IntervalMax,
                    IntervalMin = x.IntervalMin
                }).ToListAsync();

            decimal Boy = (int)request.CalcBMI.Size;
            decimal Kilo = (int)request.CalcBMI.Weight;

            decimal Hesapla = Kilo / ((Boy / 100) * (Boy / 100));

            request.CalcBMI.Result = Hesapla;

            await _calcBMIWriteRepository.AddAsync(new()
            {
                Email = request.CalcBMI.Email,
                Age = request.CalcBMI.Age,
                NameSurname = request.CalcBMI.NameSurname,
                Result = request.CalcBMI.Result,
                Size = request.CalcBMI.Size,
                Weight = request.CalcBMI.Weight
            });

            await _calcBMIWriteRepository.SaveAsync();

            return new()
            {
                BMI = new()
                {
                    CalcBMI = request.CalcBMI,
                    FixBMI = vM_FixBMI,
                    ResultBMIs = vM_ResultBMI
                }
            };
        }

        public async Task<OptimumCalculateQueryResponse> OptimumCalculateAsync()
        {
            int langId = _operationService.SessionLangId();

            VM_FixOptimum? vM_FixOptimum = await _fixOptimumReadRepository.GetWhere(x => x.LangId == langId)
                .Select(x => new VM_FixOptimum
                {
                    FormId = x.FormId,
                    Description = x.Description,
                    Id = x.Id,
                    ImgUrl = x.ImgUrl,
                    LangId = x.LangId,
                    StatusId = x.StatusId,
                    Title = x.Title
                }).FirstOrDefaultAsync();

            List<VM_Gender> vM_Genders = await _gendersReadRepository.GetWhere(x => x.LangId == langId)
                .Select(x => new VM_Gender
                {
                    Id = x.Id,
                    Gender = x.Gender,
                    LangId = x.LangId
                }).ToListAsync();


            return new()
            {
                Genders = vM_Genders,
                Optimum = new()
                {
                    CalcOptimum = null,
                    FixOptimum = vM_FixOptimum,
                    ResultOptimum = null
                }
            };
        }

        public async Task<OptimumCalculateCreateCommandResponse> OptimumCalculateCreateAsync(OptimumCalculateCreateCommandRequest request)
        {
            VM_FixOptimum? vM_FixOptimum = await _fixOptimumReadRepository.GetAll()
                .Select(x => new VM_FixOptimum
                {
                    FormId = x.FormId,
                    Description = x.Description,
                    Id = x.Id,
                    ImgUrl = x.ImgUrl,
                    LangId = x.LangId,
                    StatusId = x.StatusId,
                    Title = x.Title
                }).FirstOrDefaultAsync();

            VM_ResultOptimum? vM_ResultOptimum = await _resultOptimumReadRepository.GetAll()
                .Select(x=> new VM_ResultOptimum
                {
                    Id= x.Id,
                    Result1text = x.Result1text,
                    Result2text = x.Result2text,
                    Result3text = x.Result3text,
                    Result4text = x.Result4text
                })
                .FirstOrDefaultAsync();

            double Boy = (int)request.CalcOptimum.Size;
            double Kilo = (int)request.CalcOptimum.Weight;


            #region Vücut Yüzey Alanı

            double VYA = Math.Sqrt((Boy * Kilo / 3600));
            request.CalcOptimum.Result1 = Math.Round(Convert.ToDecimal(VYA), 2);

            #endregion

            #region Yağsız Vücut Ağırlığı

            if (request.CalcOptimum.Gender.Trim().ToLower() == "Erkek" || request.CalcOptimum.Gender.Trim().ToUpper() == "Erkek" || request.CalcOptimum.Gender.Trim().ToLower() == "Male" || request.CalcOptimum.Gender.Trim().ToUpper() == "Male")
            {
                double YVA = (1.10 * Kilo) - (128 * (Kilo * Kilo) / (Boy * Boy));
                request.CalcOptimum.Result2 = Math.Round(Convert.ToDecimal(YVA), 2);
            }
            else if (request.CalcOptimum.Gender.Trim().ToLower() == "Kadın" || request.CalcOptimum.Gender.Trim().ToUpper() == "Kadın" || request.CalcOptimum.Gender.Trim().ToLower() == "Female" || request.CalcOptimum.Gender.Trim().ToUpper() == "Female")
            {
                double YVA = (1.07 * Kilo) - (148 * (Kilo * Kilo) / (Boy * Boy));
                request.CalcOptimum.Result2 = Math.Round(Convert.ToDecimal(YVA), 2);
            }

            #endregion

            #region Ideal Vücut Ağırlığı

            double boyIn = Boy * 0.393700787;
            if (request.CalcOptimum.Gender.Trim().ToLower() == "Erkek" || request.CalcOptimum.Gender.Trim().ToUpper() == "Erkek" || request.CalcOptimum.Gender.Trim().ToLower() == "Male" || request.CalcOptimum.Gender.Trim().ToUpper() == "Male")
            {
                double IVA = 50 + (2.3 * (boyIn - 60));
                request.CalcOptimum.Result3 = Math.Round(Convert.ToDecimal(IVA), 2);
            }
            else if (request.CalcOptimum.Gender.Trim().ToLower() == "Kadın" || request.CalcOptimum.Gender.Trim().ToUpper() == "Kadın" || request.CalcOptimum.Gender.Trim().ToLower() == "Female" || request.CalcOptimum.Gender.Trim().ToUpper() == "Female")
            {
                double IVA = 45.5 + (2.3 * (boyIn - 60));
                request.CalcOptimum.Result3 = Math.Round(Convert.ToDecimal(IVA), 2);
            }

            #endregion

            #region Vücud Kitle İndeksi

            double BMI = Kilo / ((Boy / 100) * (Boy / 100));
            request.CalcOptimum.Result4 = Math.Round(Convert.ToDecimal(BMI), 2);

            #endregion

            await _calcOptimumWriteRepository.AddAsync(new()
            {
                Age = request.CalcOptimum.Age,
                Email = request.CalcOptimum.Email,
                NameSurname = request.CalcOptimum.NameSurname,
                Result1 = request.CalcOptimum.Result1,
                Result2 = request.CalcOptimum.Result2,
                Result3 = request.CalcOptimum.Result3,
                Result4 = request.CalcOptimum.Result4,
                Size = request.CalcOptimum.Size,
                Weight = request.CalcOptimum.Weight,
                Gender = request.CalcOptimum.Gender
            });

            await _calcOptimumWriteRepository.SaveAsync();

            return new()
            {
                Optimum = new()
                {
                    CalcOptimum = request.CalcOptimum,
                    FixOptimum = vM_FixOptimum,
                    ResultOptimum = vM_ResultOptimum
                }
            };
        }

        #endregion

        #region UIWorkShop

        public async Task<GetWhereWorkShopQueryResponse> GetWhereWorkShopAsync()
        {
            int langId = _operationService.SessionLangId();
            int statusId = await _statusReadRepository.GetWhere(x => x.StatusName == "Aktif").Select(x => x.Id).FirstAsync();

            List<VM_Workshop> vM_Workshops = await _workshopReadRepository.GetWhere(x => x.LangId == langId && x.StatusId == statusId)
                .Join(_workshopEducationReadRepository.GetAll(), w => w.WseducationId, education => education.Id, (w, education) => new { w, education })
                .Join(_workshopCategoryReadRepository.GetAll(), wo => wo.education.WscategoryId, category => category.Id, (wo, category) => new { wo, category })
                .Join(_workshopTypeReadRepository.GetAll(), work => work.wo.w.WstypeId, wType => wType.Id, (work, wType) => new { work, wType })
                .Select(x => new VM_Workshop
                {
                    Id = x.work.wo.w.Id,
                    Address = x.work.wo.w.Address,
                    CreateDate = x.work.wo.w.CreateDate,
                    CreateUserId = x.work.wo.w.CreateUserId,
                    Description = x.work.wo.w.Description,
                    FinishDateTime = x.work.wo.w.FinishDateTime,
                    IsMainPage = x.work.wo.w.IsMainPage,
                    LangId = x.work.wo.w.LangId,
                    NavigationId = x.work.wo.w.NavigationId,
                    Orders = x.work.wo.w.Orders,
                    Price = x.work.wo.w.Price,
                    StartDateTime = x.work.wo.w.StartDateTime,
                    StatusId = x.work.wo.w.StatusId,
                    Title = x.work.wo.w.Title,
                    WseducationId = x.work.wo.w.WseducationId,
                    WstypeId = x.work.wo.w.WstypeId,
                    WsEducationName = x.work.wo.education.WsEducationName,
                    WstypeName = x.wType.WstypeName,
                    WscategoryName = x.work.category.WscategoryName
                }).ToListAsync();

            return new()
            {
                Workshops = vM_Workshops
            };
        }


        #endregion
    }
}
