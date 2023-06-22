using MVCBlogApp.Application.Features.Queries.UIHome.UIHomeArticlePreviews;
using MVCBlogApp.Application.Features.Queries.UIHome.UIHomeLatestNews;
using MVCBlogApp.Application.Features.Queries.UIHome.UIHomeRightVideo;
using MVCBlogApp.Application.Features.Queries.UIHome.UIHomeSlider;

namespace MVCBlogApp.Application.Abstractions.Services
{
    public interface IUIHomeService
    {
        #region UIHomeSlider

        Task<UIHomeSliderQueryResponse> UIHomeSliderAsync();
        Task<UIHomeArticlePreviewsQueryResponse> UIHomeArticlePreviewsAsync();
        Task<UIHomeRightVideoQueryResponse> UIHomeRightVideoAsync();
        Task<UIHomeLatestNewsQueryResponse> UIHomeLatestNewsAsync();

        #endregion
    }
}
