using Microsoft.EntityFrameworkCore;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Features.Queries.UIHome.UIHomeSlider;
using MVCBlogApp.Application.Repositories.Carousel;
using MVCBlogApp.Application.Repositories.Status;
using MVCBlogApp.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCBlogApp.Persistence.Services
{
    public class UIHomeService : IUIHomeService
    {
        private readonly IOperationService _operationService;
        private readonly IStatusReadRepository _statusReadRepository;
        private readonly ICarouselReadRepository _carouselReadRepository;

        public UIHomeService(IOperationService operationService, IStatusReadRepository statusReadRepository, ICarouselReadRepository carouselReadRepository)
        {
            _operationService = operationService;
            _statusReadRepository = statusReadRepository;
            _carouselReadRepository = carouselReadRepository;
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

        #endregion
    }
}
