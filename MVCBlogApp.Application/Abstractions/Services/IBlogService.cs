using MVCBlogApp.Application.Features.Commands.Blog.BlogCreate;
using MVCBlogApp.Application.Features.Commands.Blog.BlogDelete;
using MVCBlogApp.Application.Features.Commands.BlogCategory.BlogCategoryCreate;
using MVCBlogApp.Application.Features.Commands.BlogCategory.BlogCategoryDelete;
using MVCBlogApp.Application.Features.Commands.BlogCategory.BlogCategoryUpdate;
using MVCBlogApp.Application.Features.Commands.BlogType.BlogTypeCreate;
using MVCBlogApp.Application.Features.Commands.BlogType.BlogTypeDelete;
using MVCBlogApp.Application.Features.Commands.BlogType.BlogTypeUpdate;
using MVCBlogApp.Application.Features.Queries.Blog.GetAllBlog;
using MVCBlogApp.Application.Features.Queries.Blog.GetBlogCreateItems;
using MVCBlogApp.Application.Features.Queries.BlogCategory.GetAllBlogCategory;
using MVCBlogApp.Application.Features.Queries.BlogCategory.GetBlogCategoryItem;
using MVCBlogApp.Application.Features.Queries.BlogCategory.GetByIdBlogCategory;
using MVCBlogApp.Application.Features.Queries.BlogType.GetAllBlogType;
using MVCBlogApp.Application.Features.Queries.BlogType.GetBlogTypeCreateItems;
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
        Task<GetBlogTypeCreateItemsQueryResponse> GetBlogTypeCreateItemsAsync();
        #endregion

        #region BlogCategory

        Task<GetBlogCategoryItemQueryResponse> GetBlogCategoryItemAsync();
        Task<BlogCategoryCreateCommandResponse> BlogCategoryCreateAsync(BlogCategoryCreateCommandRequest request);
        Task<GetAllBlogCategoryQueryResponse> GetAllBlogCategoryAsync();
        Task<GetByIdBlogCategoryQueryResponse> GetByIdBlogCategoryAsync(GetByIdBlogCategoryQueryRequest request);
        Task<BlogCategoryUpdateQueryResponse> BlogCategoryUpdateAsync(BlogCategoryUpdateQueryRequest request);
        Task<BlogCategoryDeleteCommandResponse> BlogCategoryDeleteAsync(BlogCategoryDeleteCommandRequest request);
        #endregion

        #region Blog

        Task<GetBlogCreateItemsQueryResponse> GetBlogCreateItemsAsync();
        Task<BlogCreateCommandResponse> BlogCreateAsync(BlogCreateCommandRequest request);
        Task<GetAllBlogQueryResponse> GetAllBlogAsync();
        Task<BlogDeleteCommandResponse> BlogDeleteAsync(BlogDeleteCommandRequest request);

        #endregion
    }
}
