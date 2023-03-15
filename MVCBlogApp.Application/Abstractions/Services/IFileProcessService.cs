using MVCBlogApp.Application.Features.Commands.File.VideoCategory.VideoCategoryCreate;
using MVCBlogApp.Application.Features.Commands.File.VideoCategory.VideoCategoryDelete;
using MVCBlogApp.Application.Features.Commands.File.VideoCategory.VideoCategoryUpdate;
using MVCBlogApp.Application.Features.Queries.File.VideoCategory.GetAllVideoCategory;
using MVCBlogApp.Application.Features.Queries.File.VideoCategory.GetByIdVideoCategory;
using MVCBlogApp.Application.Features.Queries.File.VideoCategory.GetVideoCategoryCreateItems;

namespace MVCBlogApp.Application.Abstractions.Services
{
    public interface IFileProcessService
    {
        #region Image

        #endregion

        #region Video

        #endregion

        #region VideoCategory

        Task<GetVideoCategoryCreateItemsQueryResponse> GetVideoCategoryCreateItemsAsync();
        Task<GetAllVideoCategoryQueryResponse> GetAllVideoCategoryAsync();
        Task<VideoCategoryCreateCommandResponse> VideoCategoryCreateAsync(VideoCategoryCreateCommandRequest request);
        Task<GetByIdVideoCategoryQueryResponse> GetByIdVideoCategoryAsync(int id);
        Task<VideoCategoryUpdateCommandResponse> VideoCategoryUpdateAsync(VideoCategoryUpdateCommandRequest request);
        Task<VideoCategoryDeleteCommandResponse> VideoCategoryDeleteAsync(int id);

        #endregion
    }
}
