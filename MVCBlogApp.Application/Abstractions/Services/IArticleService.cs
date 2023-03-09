using MVCBlogApp.Application.Features.Commands.Article.Article.ArticleCreate;
using MVCBlogApp.Application.Features.Commands.Article.ArticleCategory.ArticleCategoryCreate;
using MVCBlogApp.Application.Features.Commands.Article.ArticleCategory.ArticleCategoryDelete;
using MVCBlogApp.Application.Features.Commands.Article.ArticleCategory.ArticleCategoryUpdate;
using MVCBlogApp.Application.Features.Queries.Article.Article.GetAllArticle;
using MVCBlogApp.Application.Features.Queries.Article.Article.GetArticleCreateItems;
using MVCBlogApp.Application.Features.Queries.Article.ArticleCategory.GetAllArticleCategory;
using MVCBlogApp.Application.Features.Queries.Article.ArticleCategory.GetArticleCategoryCreateItems;
using MVCBlogApp.Application.Features.Queries.Article.ArticleCategory.GetByIdArticleCategory;

namespace MVCBlogApp.Application.Abstractions.Services
{
    public interface IArticleService
    {
        #region Article

        Task<GetArticleCreateItemsQueryResponse> GetArticleCreateItemsAsync();
        Task<GetAllArticleQueryResponse> GetAllArticleAsync();
        Task<ArticleCreateCommandResponse> ArticleCreateAsync(ArticleCreateCommandRequest request);

        #endregion

        #region ArticleCategory

        Task<GetArticleCategoryCreateItemsQueryResponse> GetArticleCategoryCreateItemsAsync();
        Task<GetAllArticleCategoryQueryResponse> GetAllArticleCategoryAsync();
        Task<ArticleCategoryCreateCommandResponse> ArticleCategoryCreateAsync(ArticleCategoryCreateCommandRequest request);
        Task<GetByIdArticleCategoryQueryResponse> GetByIdArticleCategoryAsync(int id);
        Task<ArticleCategoryUpdateCommandResponse> ArticleCategoryUpdateAsync(ArticleCategoryUpdateCommandRequest request);
        Task<ArticleCategoryDeleteCommandResponse> ArticleCategoryDeleteAsync(int id);

        #endregion
    }
}
