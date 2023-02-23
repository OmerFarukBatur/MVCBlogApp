using MVCBlogApp.Application.Features.Commands.BlogCategory.BlogCategoryCreate;
using MVCBlogApp.Application.Features.Commands.BlogType.BlogTypeCreate;
using MVCBlogApp.Application.Features.Commands.BlogType.BlogTypeDelete;
using MVCBlogApp.Application.Features.Commands.BlogType.BlogTypeUpdate;
using MVCBlogApp.Application.Features.Queries.BlogCategory.GetAllBlogCategory;
using MVCBlogApp.Application.Features.Queries.BlogCategory.GetBlogCategoryItem;
using MVCBlogApp.Application.Features.Queries.BlogType.GetAllBlogType;
using MVCBlogApp.Application.Features.Queries.BlogType.GetByIdBlogType;

namespace MVCBlogApp.Application.Abstractions.Services
{
    public interface IBlogService
    {
        #region BlogType
        Task<BlogTypeCreateCommandResponse> BlogTypeCreateAsync(BlogTypeCreateCommandRequest request);
        Task<GetByIdBlogTypeQueryResponse> GetByIdBlogTypeAsync(GetByIdBlogTypeQueryRequest request);
        Task<BlogTypeUpdateCommandResponse> BlogTypeUpdateAsync(BlogTypeUpdateCommandRequest request);
        Task<GetAllBlogTypeQueryResponse> GetAllBlogTypeAsync();
        Task<BlogTypeDeleteCommandResponse> BlogTypeDeleteAsync(BlogTypeDeleteCommandRequest request);
        #endregion

        #region BlogCategory

        Task<GetBlogCategoryItemQueryResponse> GetBlogCategoryItemAsync();
        Task<BlogCategoryCreateCommandResponse> BlogCategoryCreateAsync(BlogCategoryCreateCommandRequest request);
        Task<GetAllBlogCategoryQueryResponse> GetAllBlogCategoryAsync();

        #endregion
    }
}
