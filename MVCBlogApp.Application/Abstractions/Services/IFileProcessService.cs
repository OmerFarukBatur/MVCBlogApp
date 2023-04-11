using MVCBlogApp.Application.Features.Commands.File.Banner.BannerCreate;
using MVCBlogApp.Application.Features.Commands.File.Banner.BannerDelete;
using MVCBlogApp.Application.Features.Commands.File.Banner.BannerUpdate;
using MVCBlogApp.Application.Features.Commands.File.Carousel.CarouselCreate;
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

namespace MVCBlogApp.Application.Abstractions.Services
{
    public interface IFileProcessService
    {
        #region Image

        Task<GetUploadImageItemsQueryResponse> GetUploadImageItemsAsync();
        Task<ImageUploadCommandResponse> ImageUploadAsync(ImageUploadCommandRequest request);
        Task<GetAllImageQueryResponse> GetAllImageAsync();
        Task<GetByIdImageQueryResponse> GetByIdImageAsync(int id);
        Task<ImageUpdateCommandResponse> ImageUpdateAsync(ImageUpdateCommandRequest request);
        Task<ImageDeleteCommandResponse> ImageDeleteAsync(int id);

        #endregion

        #region Video

        Task<GetVideoCreateItemsQueryResponse> GetVideoCreateItemsAsync();
        Task<VideoCreateCommandResponse> VideoCreateAsync(VideoCreateCommandRequest request);
        Task<GetAllVideoQueryResponse> GetAllVideoAsync();
        Task<GetByIdVideoQueryResponse> GetByIdVideoAsync(int id);
        Task<VideoUpdateCommandResponse> VideoUpdateAsync(VideoUpdateCommandRequest request);
        Task<VideoDeleteCommandResponse> VideoDeleteAsync(int id);

        #endregion

        #region VideoCategory

        Task<GetVideoCategoryCreateItemsQueryResponse> GetVideoCategoryCreateItemsAsync();
        Task<GetAllVideoCategoryQueryResponse> GetAllVideoCategoryAsync();
        Task<VideoCategoryCreateCommandResponse> VideoCategoryCreateAsync(VideoCategoryCreateCommandRequest request);
        Task<GetByIdVideoCategoryQueryResponse> GetByIdVideoCategoryAsync(int id);
        Task<VideoCategoryUpdateCommandResponse> VideoCategoryUpdateAsync(VideoCategoryUpdateCommandRequest request);
        Task<VideoCategoryDeleteCommandResponse> VideoCategoryDeleteAsync(int id);

        #endregion

        #region Banner

        Task<GetBannerCreateItemsQueryResponse> GetBannerCreateItemsAsync();
        Task<GetAllBannerQueryResponse> GetAllBannerAsync();
        Task<BannerCreateCommandResponse> BannerCreateAsync(BannerCreateCommandRequest request);
        Task<GetByIdBannerQueryResponse> GetByIdBannerAsync(int id);
        Task<BannerUpdateQueryResponse> BannerUpdateAsync(BannerUpdateQueryRequest request);
        Task<BannerDeleteCommandResponse> BannerDeleteAsync(int id);

        #endregion

        #region Carousel

        Task<GetCarouselCreateItemsQueryResponse> GetCarouselCreateItemsAsync();
        Task<GetAllCarouselQueryResponse> GetAllCarouselAsync();
        Task<CarouselCreateCommandResponse> CarouselCreateAsync(CarouselCreateCommandRequest request);

        #endregion
    }
}
