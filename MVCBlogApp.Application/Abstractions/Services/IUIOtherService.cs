using MVCBlogApp.Application.Features.Queries.UIArticle.UIArticleIndex;
using MVCBlogApp.Application.Features.Queries.UIArticle.UILeftNavigation;
using MVCBlogApp.Application.Features.Queries.UIBlog.UIBlogPartialView;

namespace MVCBlogApp.Application.Abstractions.Services
{
    public interface IUIOtherService
    {
        #region Article

        Task<UILeftNavigationQueryResponse> UILeftNavigationAsync(UILeftNavigationQueryRequest request);
        Task<UIArticleIndexQueryResponse> UIArticleIndexAsync(UIArticleIndexQueryRequest request);

        #endregion

        #region Blog

        Task<UIBlogPartialViewQueryResponse> UIBlogPartialViewAsync(UIBlogPartialViewQueryRequest request);

        #endregion
    }
}
