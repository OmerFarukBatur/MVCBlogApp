using MVCBlogApp.Application.Features.Queries.Fix.FixBmh.GetAllFixBmhs;
using MVCBlogApp.Application.Features.Queries.Fix.FixBmh.GetFixBmhCreateItems;

namespace MVCBlogApp.Application.Abstractions.Services
{
    public interface IFixService
    {
        #region FixBmh

        Task<GetFixBmhCreateItemsQueryResponse> GetFixBmhCreateItemsAsync();
        Task<GetAllFixBmhsQueryResponse> GetAllFixBmhsAsync();

        #endregion

        #region FixBMI
        #endregion

        #region FixCalorieSch
        #endregion

        #region FixFeedPyramid
        #endregion

        #region FixHeartDiseases
        #endregion

        #region FixMealSize
        #endregion

        #region FixOptimum
        #endregion

        #region FixPulse
        #endregion
    }
}
