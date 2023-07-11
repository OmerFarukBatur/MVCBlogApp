using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Features.Queries.IULayout.UILayoutBanner;
using MVCBlogApp.Application.Features.Queries.IULayout.UILayoutFooter;
using MVCBlogApp.Application.Features.Queries.IULayout.UILayoutHeaderMenu;
using MVCBlogApp.Application.Features.Queries.IULayout.UILayoutHeaderTopMenu;
using MVCBlogApp.Application.Features.Queries.UIHome.UIHomeArticlePreviews;
using MVCBlogApp.Application.Features.Queries.UIHome.UIHomeIndex;
using MVCBlogApp.Application.Features.Queries.UIHome.UIHomeLatestNews;
using MVCBlogApp.Application.Features.Queries.UIHome.UIHomeRightVideo;
using MVCBlogApp.Application.Features.Queries.UIHome.UIHomeSlider;
using MVCBlogApp.Application.Repositories.Article;
using MVCBlogApp.Application.Repositories.Banner;
using MVCBlogApp.Application.Repositories.Blog;
using MVCBlogApp.Application.Repositories.Book;
using MVCBlogApp.Application.Repositories.Carousel;
using MVCBlogApp.Application.Repositories.Members;
using MVCBlogApp.Application.Repositories.Navigation;
using MVCBlogApp.Application.Repositories.SLeftNavigation;
using MVCBlogApp.Application.Repositories.Status;
using MVCBlogApp.Application.Repositories.TaylanK;
using MVCBlogApp.Application.Repositories.User;
using MVCBlogApp.Application.Repositories.Video;
using MVCBlogApp.Application.Repositories.VideoCategory;
using MVCBlogApp.Application.ViewModels;
using MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Services
{
    public class UIHomeService : IUIHomeService
    {
        private readonly IOperationService _operationService;
        private readonly IStatusReadRepository _statusReadRepository;
        private readonly ICarouselReadRepository _carouselReadRepository;
        private readonly IArticleReadRepository _articleReadRepository;
        private readonly IBlogReadRepository _blogReadRepository;
        private readonly INavigationReadRepository _navigationReadRepository;
        private readonly IVideoReadRepository _videoReadRepository;
        private readonly IVideoCategoryReadRepository _videoCategoryReadRepository;
        private readonly IMembersReadRepository _membersReadRepository;
        private readonly IUserReadRepository _userReadRepository;
        private readonly ITaylanKReadRepository _waylanKReadRepository;
        private readonly IBookReadRepository _bookReadRepository;
        private readonly IBannerReadRepository _bannerReadRepository;
        private readonly IBannerWriteRepository _bannerWriteRepository;
        private readonly ITaylanKReadRepository _taylanKReadRepository;
        private readonly ISLeftNavigationReadRepository _sLeftNavigationReadRepository;

        public UIHomeService(
            IOperationService operationService,
            IStatusReadRepository statusReadRepository,
            ICarouselReadRepository carouselReadRepository,
            IArticleReadRepository articleReadRepository,
            IBlogReadRepository blogReadRepository,
            INavigationReadRepository navigationReadRepository,
            IVideoReadRepository videoReadRepository,
            IVideoCategoryReadRepository videoCategoryReadRepository,
            IMembersReadRepository membersReadRepository,
            IUserReadRepository userReadRepository,
            ITaylanKReadRepository waylanKReadRepository,
            IBookReadRepository bookReadRepository,
            IBannerReadRepository bannerReadRepository,
            IBannerWriteRepository bannerWriteRepository,
            ITaylanKReadRepository taylanKReadRepository,
            ISLeftNavigationReadRepository sLeftNavigationReadRepository)
        {
            _operationService = operationService;
            _statusReadRepository = statusReadRepository;
            _carouselReadRepository = carouselReadRepository;
            _articleReadRepository = articleReadRepository;
            _blogReadRepository = blogReadRepository;
            _navigationReadRepository = navigationReadRepository;
            _videoReadRepository = videoReadRepository;
            _videoCategoryReadRepository = videoCategoryReadRepository;
            _membersReadRepository = membersReadRepository;
            _userReadRepository = userReadRepository;
            _waylanKReadRepository = waylanKReadRepository;
            _bookReadRepository = bookReadRepository;
            _bannerReadRepository = bannerReadRepository;
            _bannerWriteRepository = bannerWriteRepository;
            _taylanKReadRepository = taylanKReadRepository;
            _sLeftNavigationReadRepository = sLeftNavigationReadRepository;
        }




        #region UIHomeSlider

        public async Task<UIHomeSliderQueryResponse> UIHomeSliderAsync()
        {
            int langId = _operationService.SessionLangId();
            int statusActiveId = await _statusReadRepository.GetWhere(x => x.StatusName == "Aktif").Select(x => x.Id).FirstAsync();
            List<VM_Carousel> vM_Carousels = await _carouselReadRepository.GetWhere(x => x.LangId == langId && x.StatusId == statusActiveId)
                .Select(x => new VM_Carousel
                {
                    Action = x.Action,
                    Controller = x.Controller,
                    CreateDate = x.CreateDate,
                    CreateUserId = x.CreateUserId,
                    Description = x.Description,
                    Id = x.Id,
                    ImgName = x.ImgName,
                    ImgUrl = x.ImgUrl,
                    Orders = x.Orders,
                    LangId = x.LangId,
                    MetaDescription = x.MetaDescription,
                    MetaKey = x.MetaKey,
                    MetaTitle = x.MetaTitle,
                    StatusId = x.StatusId,
                    Title = x.Title,
                    TitleClass = x.TitleClass,
                    UrlRoot = x.UrlRoot
                }).OrderBy(x => x.Orders).ToListAsync();

            return new()
            {
                Carousels = vM_Carousels
            };
        }

        public async Task<UIHomeArticlePreviewsQueryResponse> UIHomeArticlePreviewsAsync()
        {
            int langId = _operationService.SessionLangId();
            int statusActiveId = await _statusReadRepository.GetWhere(x => x.StatusName == "Aktif").Select(x => x.Id).FirstAsync();

            List<VM_Navigation> articles = new();

            articles.AddRange(await _articleReadRepository
                .GetWhere(x => x.StatusId == statusActiveId && x.LangId == langId && x.IsMainPage == true)
                .Join(_navigationReadRepository.GetAll(), ar => ar.NavigationId, na => na.Id, (ar, na) => new { ar, na })
                .Select(x => new VM_Navigation
                {
                    Id = x.ar.Id,
                    MetaKey = x.ar.MetaKey,
                    MetaTitle = x.ar.MetaTitle,
                    NavigationName = x.ar.Title,
                    ParentId = x.ar.NavigationId,
                    UrlRoot = x.ar.UrlRoot,
                    ImageUrl = x.ar.CoverImgUrl,
                    Description = x.ar.SubTitle,
                    ArticlePreviewTitle = x.na.NavigationName
                }).ToListAsync());

            articles.AddRange(await _blogReadRepository
                .GetWhere(x => x.StatusId == statusActiveId && x.LangId == langId && x.IsMainPage == true)
                .Join(_navigationReadRepository.GetAll(), bl => bl.NavigationId, na => na.Id, (bl, na) => new { bl, na })
                .Select(x => new VM_Navigation
                {
                    Id = x.bl.Id,
                    MetaKey = x.bl.MetaKey,
                    MetaTitle = x.bl.MetaTitle,
                    NavigationName = x.bl.Title,
                    ParentId = x.bl.NavigationId,
                    UrlRoot = x.bl.UrlRoot,
                    ImageUrl = x.bl.CoverImgUrl,
                    Description = x.bl.SubTitle,
                    ArticlePreviewTitle = x.na.NavigationName
                }).ToListAsync());

            //articles.OrderByDescending(s => s.CreateDate);

            return new()
            {
                Articles = articles,
                LangId = langId
            };
        }

        public async Task<UIHomeRightVideoQueryResponse> UIHomeRightVideoAsync()
        {
            int langId = _operationService.SessionLangId();
            int statusActiveId = await _statusReadRepository.GetWhere(x => x.StatusName == "Aktif").Select(x => x.Id).FirstAsync();

            VM_Video? vM_Video = await _videoReadRepository.GetWhere(x => x.StatusId == statusActiveId && x.LangId == langId)
                .Join(_videoCategoryReadRepository.GetWhere(x => x.VideoCategoryName == "Sol Menu Video"), vi => vi.VideoCategoryId, vc => vc.Id, (vi, vc) => new { vi, vc })
                .Select(x => new VM_Video
                {
                    Id = x.vi.Id,
                    CreateDate = x.vi.CreateDate,
                    CreateUserId = x.vi.CreateUserId,
                    Description = x.vi.Description,
                    LangId = x.vi.LangId,
                    StatusId = x.vi.StatusId,
                    Title = x.vi.Title,
                    VideoCategoryId = x.vi.VideoCategoryId,
                    VideoEmbedCode = x.vi.VideoEmbedCode,
                    VideoUrl = x.vi.VideoUrl
                }).OrderByDescending(x => x.Id).LastOrDefaultAsync();



            return new()
            {
                LangId = langId,
                Video = vM_Video
            };
        }

        public async Task<UIHomeLatestNewsQueryResponse> UIHomeLatestNewsAsync()
        {
            int langId = _operationService.SessionLangId();
            int statusActiveId = await _statusReadRepository.GetWhere(x => x.StatusName == "Aktif").Select(x => x.Id).FirstAsync();

            List<VM_LatestNew> vM_LatestNews = new();

            vM_LatestNews.AddRange(await _articleReadRepository
                .GetWhere(x => x.StatusId == statusActiveId && x.LangId == langId && x.IsNewsComponent == true)
                .Select(x => new VM_LatestNew
                {
                    Id = x.Id,
                    CoveCoverImgUrl = x.CoverImgUrl,
                    CreateDate = x.CreateDate.Value,
                    SubTitle = _operationService.MakeShorter(x.SubTitle, 100),
                    Title = _operationService.MakeShorter(x.Title, 100),
                    UrlRoot = x.UrlRoot
                }).ToListAsync());

            vM_LatestNews.AddRange(await _blogReadRepository
                .GetWhere(x => x.StatusId == statusActiveId && x.LangId == langId && x.IsNewsComponent == true)
                .Select(x => new VM_LatestNew
                {
                    Id = x.Id,
                    CoveCoverImgUrl = x.CoverImgUrl,
                    CreateDate = x.CreateDate.Value,
                    SubTitle = _operationService.MakeShorter(x.SubTitle, 100),
                    Title = _operationService.MakeShorter(x.Title, 100),
                    UrlRoot = x.UrlRoot
                }).ToListAsync());

            //vM_LatestNews.OrderByDescending(x => x.CreateDate);

            return new()
            {
                LangId = langId,
                LatestNews = vM_LatestNews,
            };
        }

        public async Task<UIHomeIndexQueryResponse> UIHomeIndexAsync()
        {
            int langId = _operationService.SessionLangId();
            VM_TaylanK? vM_TaylanK = await _waylanKReadRepository.GetWhere(x => x.LangId == langId)
                .Select(x => new VM_TaylanK
                {
                    Id = x.Id,
                    Metadescription = x.Metadescription,
                    Metakey = x.Metakey,
                    Metatitle = x.Metatitle
                }).FirstOrDefaultAsync();

            return new()
            {
                LangId = langId,
                TaylanK = vM_TaylanK
            };

        }

        #endregion

        #region UILayout

        public async Task<UILayoutHeaderTopMenuQueryResponse> UILayoutHeaderTopMenuAsync()
        {
            int userId = _operationService.GetUser().Id;
            string email = _operationService.GetUser().Email;

            User? user = await _userReadRepository.GetWhere(x => x.Id == userId && x.Email == email).FirstOrDefaultAsync();
            Members? member = await _membersReadRepository.GetWhere(x => x.Id == userId && x.Email == email).FirstOrDefaultAsync();

            if (user != null)
            {
                return new()
                {
                    NameSurname = user.Username
                };
            }
            else if (member != null)
            {
                return new()
                {
                    NameSurname = member.NameSurname
                };
            }
            else
            {
                return new()
                {
                    NameSurname = null
                };
            }
        }

        public async Task<UILayoutHeaderMenuQueryResponse> UILayoutHeaderMenuAsync()
        {
            int langId = _operationService.SessionLangId();
            int statusActiveId = await _statusReadRepository.GetWhere(x => x.StatusName == "Aktif").Select(x => x.Id).FirstAsync();

            List<VM_Navigation> navigations = new();

            //Article
            List<VM_Article> articles = await _articleReadRepository.GetWhere(x => x.NavigationId != null && x.StatusId == statusActiveId && x.IsMenu != false && x.LangId == langId).OrderBy(x => x.Orders).Select(y => new VM_Article
            {
                Action = y.Action,
                NavigationId = y.NavigationId,
                Id = y.Id,
                ArticleCategoryId = y.ArticleCategoryId,
                ArticleDate = y.ArticleDate,
                AuthorUserId = y.AuthorUserId,
                Controller = y.Controller,
                CoverImgUrl = y.CoverImgUrl,
                CreateDate = y.CreateDate,
                CreateUserId = y.CreateUserId,
                Description = y.Description,
                FontAwesomeIcon = y.FontAwesomeIcon,
                IsComponent = y.IsComponent,
                IsMainPage = y.IsMainPage,
                IsMenu = y.IsMenu,
                IsNewsComponent = y.IsNewsComponent,
                LangId = y.LangId,
                MetaDescription = y.MetaDescription,
                MetaKey = y.MetaKey,
                MetaTitle = y.MetaTitle,
                Orders = y.Orders,
                StatusId = y.StatusId,
                SubTitle = y.SubTitle,
                Title = y.Title,
                UpdateDate = y.UpdateDate,
                UpdateUserId = y.UpdateUserId,
                UrlRoot = y.UrlRoot
            }).ToListAsync();


            navigations.AddRange(articles.OrderBy(x => x.Orders).Select(y => new VM_Navigation
            {
                Action = y.Action,
                Controller = y.Controller,
                CreateDate = y.CreateDate,
                FontAwesomeIcon = y.FontAwesomeIcon,
                Id = (int)y.Id,
                IsAdmin = false,
                MetaKey = y.MetaKey,
                MetaTitle = y.MetaTitle,
                NavigationName = y.Title,
                ParentId = y.NavigationId,
                UrlRoot = y.UrlRoot,
                OrderNo = y.Orders.ToString()
            }));

            //Blog

            List<VM_Blog> blogs = await _blogReadRepository.GetWhere(x => x.NavigationId != null && x.IsMenu != null && x.StatusId == statusActiveId && x.BlogTypeId == 2 && x.LangId == langId).Select(y => new VM_Blog
            {
                Id = y.Id,
                Action = y.Action,
                BlogCategoryId = y.BlogCategoryId,
                BlogType = y.BlogType,
                BlogTypeId = y.BlogTypeId,
                Contents = y.Contents,
                Controller = y.Controller,
                CoverImgUrl = y.CoverImgUrl,
                CreateDate = y.CreateDate,
                CreateUserId = y.CreateUserId,
                IsComponent = y.IsComponent,
                IsMainPage = y.IsMainPage,
                IsMenu = y.IsMenu,
                IsNewsComponent = y.IsNewsComponent,
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

            navigations.AddRange(blogs.Select(y => new VM_Navigation
            {
                CreateDate = y.CreateDate,
                Id = (int)y.Id,
                MetaKey = y.MetaKey,
                MetaTitle = y.MetaTitle,
                NavigationName = y.Title,
                ParentId = y.NavigationId,
                UrlRoot = y.UrlRoot,
                OrderNo = y.Orders.ToString()
            }));

            //Book
            List<VM_Book> books = await _bookReadRepository.GetWhere(x => x.StatusId == statusActiveId && x.NavigationId != null && x.Orders != null && x.LangId == langId).OrderBy(x => x.Orders).Select(y => new VM_Book
            {
                Action = y.Action,
                BookName = y.BookName,
                Content = y.Content,
                Controller = y.Controller,
                CreateDate = y.CreateDate,
                CreateUserId = y.CreateUserId,
                Id = (int)y.Id,
                ImageUrl = y.ImageUrl,
                IsMainPage = y.IsMainPage,
                LangId = langId,
                MetaDescription = y.MetaDescription,
                MetaKey = y.MetaKey,
                MetaTitle = y.MetaTitle,
                NavigationId = y.NavigationId,
                Orders = y.Orders,
                PublicationYear = y.PublicationYear,
                StatusId = y.StatusId,
                UrlRoot = y.UrlRoot
            }).ToListAsync();

            navigations.AddRange(books.Select(y => new VM_Navigation
            {
                CreateDate = y.CreateDate,
                Id = (int)y.Id,
                NavigationName = y.BookName,
                ParentId = y.NavigationId,
                UrlRoot = y.UrlRoot,
                Action = y.Action,
                Controller = y.Controller,
                OrderNo = y.Orders.ToString()
            }));


            // Navigation

            List<VM_Navigation> newNavigation = await _navigationReadRepository.GetWhere(x => x.IsActive == true && x.IsAdmin == false && x.LangId == langId).OrderBy(x => x.ParentId).ThenBy(x => x.OrderNo).ThenBy(x => x.Id)
                .Select(y => new VM_Navigation
                {
                    Id = y.Id,
                    ParentId = y.ParentId,
                    Action = y.Action,
                    Controller = y.Controller,
                    CreateDate = y.CreateDate,
                    FontAwesomeIcon = y.FontAwesomeIcon,
                    IsActive = y.IsActive,
                    IsAdmin = y.IsAdmin,
                    IsHeader = y.IsHeader,
                    IsSubHeader = y.IsSubHeader,
                    LangId = y.LangId,
                    MetaKey = y.MetaKey,
                    MetaTitle = y.MetaTitle,
                    OrderNo = y.OrderNo,
                    Type = y.Type,
                    UrlRoot = y.UrlRoot
                }).ToListAsync();

            navigations.AddRange(newNavigation.Select(y => new VM_Navigation
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
                MenuCount = articles.Where(x => x.NavigationId == y.Id).Count() + blogs.Where(x => x.NavigationId == y.Id).Count() + books.Where(x => x.NavigationId == y.Id).Count() + newNavigation.Where(x => x.ParentId == y.Id).Count(),
                HeaderCount = newNavigation.Where(x => x.ParentId == y.Id && x.IsHeader == true).Count(),
                SubHeaderCount = newNavigation.Where(x => x.ParentId == y.Id && x.IsSubHeader == true).Count()
            }));

            return new()
            {
                Navigations = navigations
            };
        }

        public async Task<UILayoutBannerQueryResponse> UILayoutBannerAsync()
        {
            string bannerURL = "";
            int langId = _operationService.SessionLangId();
            int statusActiveId = await _statusReadRepository.GetWhere(x => x.StatusName == "Aktif").Select(x => x.Id).FirstAsync();

            string dateString = DateTime.Now.ToString("ddMMyyyy");

            var banner = await _bannerReadRepository.GetWhere(s => s.DateString == dateString && s.StatusId == statusActiveId && s.LangId == langId).FirstOrDefaultAsync();
            if (banner != null)
            {
                bannerURL = banner.BannerUrl;
            }

            string dateStringYesterday = DateTime.Now.AddDays(-1).ToString("ddMMyyyy");
            var bannerYesterday = await _bannerReadRepository.GetWhere(s => s.DateString == dateStringYesterday && s.StatusId == statusActiveId && s.LangId == langId).FirstOrDefaultAsync();
            if (bannerYesterday != null)
            {
                var bannerToday = await _bannerReadRepository.GetWhere(s => s.BannerOrder > bannerYesterday.BannerOrder && s.StatusId == statusActiveId && s.LangId == langId).OrderBy(s => s.BannerOrder).FirstOrDefaultAsync();

                if (bannerToday != null)
                {
                    bannerToday.DateString = dateString;
                    _bannerWriteRepository.Update(bannerToday);
                    await _bannerWriteRepository.SaveAsync();

                    bannerURL = bannerToday?.BannerUrl;
                }
            }

            var bannerFirst = await _bannerReadRepository.GetWhere(s => s.StatusId == statusActiveId && s.LangId == langId).OrderBy(s => s.BannerOrder).FirstOrDefaultAsync();
            if (bannerFirst != null)
            {
                bannerFirst.DateString = dateString;
                _bannerWriteRepository.Update(bannerFirst);
                await _bannerWriteRepository.SaveAsync();

                bannerURL = bannerFirst?.BannerUrl;
            }

            return new()
            {
                BannerUrl = bannerURL
            };
        }

        public async Task<UILayoutFooterQueryResponse> UILayoutFooterAsync()
        {
            int langId = _operationService.SessionLangId();
            int statusActiveId = await _statusReadRepository.GetWhere(x => x.StatusName == "Aktif").Select(x => x.Id).FirstAsync();

            VM_TaylanK? taylanK = await _taylanKReadRepository.GetWhere(s => s.LangId == langId && s.StatusId == statusActiveId)
                .Select(x => new VM_TaylanK
                {
                    About = x.About,
                    Adress = x.Adress,
                    Bio = x.Bio,
                    CompanyName = x.CompanyName,
                    CreateDate = x.CreateDate,
                    Email1 = x.Email1,
                    Email2 = x.Email2,
                    Facebook = x.Facebook,
                    GoogleMap = x.GoogleMap,
                    Id = x.Id,
                    Instagram = x.Instagram,
                    LangId = x.LangId,
                    Logo = x.Logo,
                    Metadescription = x.Metadescription,
                    Metakey = x.Metakey,
                    Metatitle = x.Metatitle,
                    Fax = x.Fax,
                    Phone1 = x.Phone1,
                    Phone2 = x.Phone2,
                    Pinterest = x.Pinterest,
                    StatusId = x.StatusId,
                    Twitter = x.Twitter,
                    UserId = x.UserId
                }).FirstOrDefaultAsync();

            List<VM_SLeftNavigation> sLeftNavigations = await _sLeftNavigationReadRepository.GetWhere(s => s.Type == 2 && s.LangId == langId)
                .Select(x => new VM_SLeftNavigation
                {
                    Id = x.Id,
                    LangId = x.LangId,
                    Title = x.Title,
                    Type = x.Type,
                    Url = x.Url
                }).ToListAsync();

            List<VM_Blog> blogs = await _blogReadRepository.GetWhere(x => x.StatusId == statusActiveId && x.IsComponent == true && x.LangId == langId).OrderByDescending(x => x.Id).Take(5).Select(y => new VM_Blog
            {
                Id = y.Id,
                Action = y.Action,
                BlogCategoryId = y.BlogCategoryId,
                BlogType = y.BlogType,
                BlogTypeId = y.BlogTypeId,
                Contents = y.Contents,
                Controller = y.Controller,
                CoverImgUrl = y.CoverImgUrl,
                CreateDate = y.CreateDate,
                CreateUserId = y.CreateUserId,
                IsComponent = y.IsComponent,
                IsMainPage = y.IsMainPage,
                IsMenu = y.IsMenu,
                IsNewsComponent = y.IsNewsComponent,
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
                Blogs = blogs,
                SLeftNavigations = sLeftNavigations,
                TaylanK = taylanK
            };
        }
        #endregion
    }
}
