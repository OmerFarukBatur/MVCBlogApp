using Microsoft.EntityFrameworkCore;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Features.Queries.IULayout.UILayoutHeaderTopMenu;
using MVCBlogApp.Application.Features.Queries.UIHome.UIHomeArticlePreviews;
using MVCBlogApp.Application.Features.Queries.UIHome.UIHomeIndex;
using MVCBlogApp.Application.Features.Queries.UIHome.UIHomeLatestNews;
using MVCBlogApp.Application.Features.Queries.UIHome.UIHomeRightVideo;
using MVCBlogApp.Application.Features.Queries.UIHome.UIHomeSlider;
using MVCBlogApp.Application.Repositories.Article;
using MVCBlogApp.Application.Repositories.Blog;
using MVCBlogApp.Application.Repositories.Carousel;
using MVCBlogApp.Application.Repositories.Members;
using MVCBlogApp.Application.Repositories.Navigation;
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
            ITaylanKReadRepository waylanKReadRepository)
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
            VM_TaylanK? vM_TaylanK = await _waylanKReadRepository.GetWhere(x=> x.LangId ==  langId)
                .Select(x=> new VM_TaylanK 
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
            else if(member != null)
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


        #endregion
    }
}
