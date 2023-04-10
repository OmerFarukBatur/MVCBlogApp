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

        #endregion
    }
}
