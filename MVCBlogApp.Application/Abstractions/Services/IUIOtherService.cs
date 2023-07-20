using MVCBlogApp.Application.Features.Queries.UIArticle.UIArticleIndex;
using MVCBlogApp.Application.Features.Queries.UIArticle.UILeftNavigation;

namespace MVCBlogApp.Application.Abstractions.Services
{
    public interface IUIOtherService
    {
        #region Article

        Task<UILeftNavigationQueryResponse> UILeftNavigationAsync(UILeftNavigationQueryRequest request);
        Task<UIArticleIndexQueryResponse> UIArticleIndexAsync(UIArticleIndexQueryRequest request);

        #endregion
    }
}
