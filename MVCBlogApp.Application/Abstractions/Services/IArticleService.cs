using MVCBlogApp.Application.Features.Commands.Article.ArticleCategory.ArticleCategoryCreate;
using MVCBlogApp.Application.Features.Queries.Article.ArticleCategory.GetAllArticleCategory;
using MVCBlogApp.Application.Features.Queries.Article.ArticleCategory.GetArticleCategoryCreateItems;

namespace MVCBlogApp.Application.Abstractions.Services
{
    public interface IArticleService
    {
        #region Article
        #endregion

        #region ArticleCategory

        Task<GetArticleCategoryCreateItemsQueryResponse> GetArticleCategoryCreateItemsAsync();
        Task<GetAllArticleCategoryQueryResponse> GetAllArticleCategoryAsync();
        Task<ArticleCategoryCreateCommandResponse> ArticleCategoryCreateAsync(ArticleCategoryCreateCommandRequest request);

        #endregion
    }
}
