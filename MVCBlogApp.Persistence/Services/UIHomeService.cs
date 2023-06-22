using Microsoft.EntityFrameworkCore;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Features.Queries.UIHome.UIHomeArticlePreviews;
using MVCBlogApp.Application.Features.Queries.UIHome.UIHomeSlider;
using MVCBlogApp.Application.Repositories.Article;
using MVCBlogApp.Application.Repositories.Blog;
using MVCBlogApp.Application.Repositories.Carousel;
using MVCBlogApp.Application.Repositories.Navigation;
using MVCBlogApp.Application.Repositories.Status;
using MVCBlogApp.Application.ViewModels;

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

        public UIHomeService(
            IOperationService operationService,
            IStatusReadRepository statusReadRepository,
            ICarouselReadRepository carouselReadRepository,
            IArticleReadRepository articleReadRepository,
            IBlogReadRepository blogReadRepository,
            INavigationReadRepository navigationReadRepository)
        {
            _operationService = operationService;
            _statusReadRepository = statusReadRepository;
            _carouselReadRepository = carouselReadRepository;
            _articleReadRepository = articleReadRepository;
            _blogReadRepository = blogReadRepository;
            _navigationReadRepository = navigationReadRepository;
        }




        #region UIHomeSlider

        public async Task<UIHomeSliderQueryResponse> UIHomeSliderAsync()
        {
            int langId = _operationService.SessionLangId();
            int statusActiveId = await _statusReadRepository.GetWhere(x => x.StatusName == "Aktif").Select(x => x.Id).FirstAsync();
            List<VM_Carousel> vM_Carousels = await _carouselReadRepository.GetWhere(x=> x.LangId == langId && x.StatusId == statusActiveId)
                .Select(x=> new VM_Carousel
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

            articles.OrderByDescending(s => s.CreateDate);

            return new()
            {
                Articles = articles,
                LangId = langId
            };
        }

        #endregion
    }
}
