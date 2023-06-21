using MVCBlogApp.Application.Features.Queries.UIHome.UIHomeSlider;

namespace MVCBlogApp.Application.Abstractions.Services
{
    public interface IUIHomeService
    {
        #region UIHomeSlider

        Task<UIHomeSliderQueryResponse> UIHomeSliderAsync();

        #endregion
    }
}
