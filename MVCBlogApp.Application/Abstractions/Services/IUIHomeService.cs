using MVCBlogApp.Application.Features.Queries.IULayout.UILayoutBanner;
using MVCBlogApp.Application.Features.Queries.IULayout.UILayoutHeaderMenu;
using MVCBlogApp.Application.Features.Queries.IULayout.UILayoutHeaderTopMenu;
using MVCBlogApp.Application.Features.Queries.UIHome.UIHomeArticlePreviews;
using MVCBlogApp.Application.Features.Queries.UIHome.UIHomeIndex;
using MVCBlogApp.Application.Features.Queries.UIHome.UIHomeLatestNews;
using MVCBlogApp.Application.Features.Queries.UIHome.UIHomeRightVideo;
using MVCBlogApp.Application.Features.Queries.UIHome.UIHomeSlider;

namespace MVCBlogApp.Application.Abstractions.Services
{
    public interface IUIHomeService
    {
        #region UIHome

        Task<UIHomeSliderQueryResponse> UIHomeSliderAsync();
        Task<UIHomeArticlePreviewsQueryResponse> UIHomeArticlePreviewsAsync();
        Task<UIHomeRightVideoQueryResponse> UIHomeRightVideoAsync();
        Task<UIHomeLatestNewsQueryResponse> UIHomeLatestNewsAsync();
        Task<UIHomeIndexQueryResponse> UIHomeIndexAsync();

        #endregion

        #region UILayout

        Task<UILayoutHeaderTopMenuQueryResponse> UILayoutHeaderTopMenuAsync();
        Task<UILayoutHeaderMenuQueryResponse> UILayoutHeaderMenuAsync();
        Task<UILayoutBannerQueryResponse> UILayoutBannerAsync();

        #endregion
    }
}
