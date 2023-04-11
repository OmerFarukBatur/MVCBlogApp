using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Features.Commands.File.Banner.BannerCreate;
using MVCBlogApp.Application.Features.Commands.File.Banner.BannerDelete;
using MVCBlogApp.Application.Features.Commands.File.Banner.BannerUpdate;
using MVCBlogApp.Application.Features.Commands.File.Carousel.CarouselCreate;
using MVCBlogApp.Application.Features.Commands.File.Carousel.CarouselDelete;
using MVCBlogApp.Application.Features.Commands.File.Carousel.CarouselUpdate;
using MVCBlogApp.Application.Features.Commands.File.Image.ImageDelete;
using MVCBlogApp.Application.Features.Commands.File.Image.ImageUpdate;
using MVCBlogApp.Application.Features.Commands.File.Image.ImageUpload;
using MVCBlogApp.Application.Features.Commands.File.Video.VideoCreate;
using MVCBlogApp.Application.Features.Commands.File.Video.VideoDelete;
using MVCBlogApp.Application.Features.Commands.File.Video.VideoUpdate;
using MVCBlogApp.Application.Features.Commands.File.VideoCategory.VideoCategoryCreate;
using MVCBlogApp.Application.Features.Commands.File.VideoCategory.VideoCategoryDelete;
using MVCBlogApp.Application.Features.Commands.File.VideoCategory.VideoCategoryUpdate;
using MVCBlogApp.Application.Features.Queries.File.Banner.GetAllBanner;
using MVCBlogApp.Application.Features.Queries.File.Banner.GetBannerCreateItems;
using MVCBlogApp.Application.Features.Queries.File.Banner.GetByIdBanner;
using MVCBlogApp.Application.Features.Queries.File.Carousel.GetAllCarousel;
using MVCBlogApp.Application.Features.Queries.File.Carousel.GetByIdCarousel;
using MVCBlogApp.Application.Features.Queries.File.Carousel.GetCarouselCreateItems;
using MVCBlogApp.Application.Features.Queries.File.Image.GetAllImage;
using MVCBlogApp.Application.Features.Queries.File.Image.GetByIdImage;
using MVCBlogApp.Application.Features.Queries.File.Image.GetUploadImageItems;
using MVCBlogApp.Application.Features.Queries.File.Video.GetAllVideo;
using MVCBlogApp.Application.Features.Queries.File.Video.GetByIdVideo;
using MVCBlogApp.Application.Features.Queries.File.Video.GetVideoCreateItems;
using MVCBlogApp.Application.Features.Queries.File.VideoCategory.GetAllVideoCategory;
using MVCBlogApp.Application.Features.Queries.File.VideoCategory.GetByIdVideoCategory;
using MVCBlogApp.Application.Features.Queries.File.VideoCategory.GetVideoCategoryCreateItems;

namespace MVCBlogApp.UI.Controllers
{
    [Authorize(Roles ="Admin")]
    public class FileController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IOperationService _operationService;

        public FileController(IMediator mediator, IOperationService operationService)
        {
            _mediator = mediator;
            _operationService = operationService;
        }

        #region Image
        public async Task<IActionResult> ImageList(GetAllImageQueryRequest request)
        {
            GetAllImageQueryResponse response = await _mediator.Send(request);
            return View(response.Images);
        }

        [HttpGet]
        public async Task<IActionResult> ImageUpload(GetUploadImageItemsQueryRequest request)
        {
            GetUploadImageItemsQueryResponse response = await _mediator.Send(request);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> ImageUpload(ImageUploadCommandRequest request)
        {
            request.CreateUserId = _operationService.GetUser().Id;
            ImageUploadCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("ImageList", "File");
            }
            else
            {
                return RedirectToAction("ImageUpload", "File");
            }
        }

        [HttpGet]
        public async Task<IActionResult> ImageUpdate(GetByIdImageQueryRequest request)
        {
            GetByIdImageQueryResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return View(response);
            }
            else
            {
                return RedirectToAction("ImageList", "File");
            }
        }

        [HttpPost]
        public async Task<IActionResult> ImageUpdate(ImageUpdateCommandRequest request)
        {
            ImageUpdateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("ImageList", "File");
            }
            else
            {
                return RedirectToAction("ImageUpdate", "File");
            }
        }

        [HttpGet]
        public async Task<IActionResult> ImageDelete(ImageDeleteCommandRequest request)
        {
            ImageDeleteCommandResponse response = await _mediator.Send(request);
            return RedirectToAction("ImageList", "File");
        }

        #endregion

        #region VideoCategory
        public async Task<IActionResult> VideoCategoryList(GetAllVideoCategoryQueryRequest request)
        {
            GetAllVideoCategoryQueryResponse response = await _mediator.Send(request);
            return View(response.VideoCategories);
        }

        [HttpGet]
        public async Task<IActionResult> VideoCategoryCreate(GetVideoCategoryCreateItemsQueryRequest request)
        {
            GetVideoCategoryCreateItemsQueryResponse response = await _mediator.Send(request);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> VideoCategoryCreate(VideoCategoryCreateCommandRequest request)
        {
            VideoCategoryCreateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("VideoCategoryList", "File");
            }
            else
            {
                return RedirectToAction("VideoCategoryCreate", "File");
            }
        }

        [HttpGet]
        public async Task<IActionResult> VideoCategoryUpdate(GetByIdVideoCategoryQueryRequest request)
        {
            GetByIdVideoCategoryQueryResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return View(response);
            }
            else
            {
                return RedirectToAction("VideoCategoryList", "File");
            }            
        }

        [HttpPost]
        public async Task<IActionResult> VideoCategoryUpdate(VideoCategoryUpdateCommandRequest request)
        {
            VideoCategoryUpdateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("VideoCategoryList", "File");
            }
            else
            {
                return RedirectToAction("VideoCategoryUpdate", "File");
            }
        }

        [HttpGet]
        public async Task<IActionResult> VideoCategoryDelete(VideoCategoryDeleteCommandRequest request)
        {
            VideoCategoryDeleteCommandResponse response = await _mediator.Send(request);
            return RedirectToAction("VideoCategoryList", "File");
        }

        #endregion

        #region Video
        public async Task<IActionResult> VideoList(GetAllVideoQueryRequest request)
        {
            GetAllVideoQueryResponse response = await _mediator.Send(request);
            return View(response.Videos);
        }

        [HttpGet]
        public async Task<IActionResult> VideoCreate(GetVideoCreateItemsQueryRequest request)
        {
            GetVideoCreateItemsQueryResponse response = await _mediator.Send(request);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> VideoCreate(VideoCreateCommandRequest request)
        {
            request.CreateUserId = _operationService.GetUser().Id;
            VideoCreateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("VideoList", "File");
            }
            else
            {
                return RedirectToAction("VideoCreate", "File");
            }
        }

        [HttpGet]
        public async Task<IActionResult> VideoUpdate(GetByIdVideoQueryRequest request)
        {
            GetByIdVideoQueryResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return View(response);
            }
            else
            {
                return RedirectToAction("VideoList", "File");
            }            
        }

        [HttpPost]
        public async Task<IActionResult> VideoUpdate(VideoUpdateCommandRequest request)
        {
            VideoUpdateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("VideoList", "File");
            }
            else
            {
                return RedirectToAction("VideoUpdate", "File");
            }
        }

        [HttpGet]
        public async Task<IActionResult> VideoDelete(VideoDeleteCommandRequest request)
        {
            VideoDeleteCommandResponse response = await _mediator.Send(request);
            return RedirectToAction("VideoList", "File");
        }

        #endregion

        #region Banner
        public async Task<IActionResult> BannerList(GetAllBannerQueryRequest request)
        {
            GetAllBannerQueryResponse response = await _mediator.Send(request);
            return View(response.Banners);
        }

        [HttpGet]
        public async Task<IActionResult> BannerCreate(GetBannerCreateItemsQueryRequest request)
        {
            GetBannerCreateItemsQueryResponse response = await _mediator.Send(request);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> BannerCreate(BannerCreateCommandRequest request)
        {
            BannerCreateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("BannerList", "File");
            }
            else
            {
                return RedirectToAction("BannerCreate", "File");
            }
        }

        [HttpGet]
        public async Task<IActionResult> BannerUpdate(GetByIdBannerQueryRequest request)
        {
            GetByIdBannerQueryResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return View(response);
            }
            else
            {
                return RedirectToAction("BannerList", "File");
            }
        }

        [HttpPost]
        public async Task<IActionResult> BannerUpdate(BannerUpdateQueryRequest request)
        {
            BannerUpdateQueryResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("BannerList", "File");
            }
            else
            {
                return RedirectToAction("BannerCreate", "File");
            }
        }

        [HttpGet]
        public async Task<IActionResult> BannerDelete(BannerDeleteCommandRequest request )
        {
            BannerDeleteCommandResponse response = await _mediator.Send(request);
            return RedirectToAction("BannerList", "File");
        }

        #endregion

        #region Carousel

        public async Task<IActionResult> CarouselList(GetAllCarouselQueryRequest request)
        {
            GetAllCarouselQueryResponse response = await _mediator.Send(request);
            return View(response.Carousels);
        }

        [HttpGet]
        public async Task<IActionResult> CarouselCreate(GetCarouselCreateItemsQueryRequest request)
        {
            GetCarouselCreateItemsQueryResponse response = await _mediator.Send(request);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> CarouselCreate(CarouselCreateCommandRequest request)
        {
            CarouselCreateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("CarouselList", "File");
            }
            else
            {
                return RedirectToAction("CarouselCreate", "File");
            }
        }

        [HttpGet]
        public async Task<IActionResult> CarouselUpdate(GetByIdCarouselQueryRequest request)
        {
            GetByIdCarouselQueryResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return View(response);
            }
            else
            {
                return RedirectToAction("CarouselList", "File");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CarouselUpdate(CarouselUpdateCommandRequest request)
        {
            CarouselUpdateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("CarouselList", "File");
            }
            else
            {
                return RedirectToAction("CarouselUpdate", "File");
            }
        }

        [HttpGet]
        public async Task<IActionResult> CarouselDelete(CarouselDeleteCommandRequest request)
        {
            CarouselDeleteCommandResponse response = await _mediator.Send(request);
            return RedirectToAction("CarouselList", "File");
        }

        #endregion
    }
}
