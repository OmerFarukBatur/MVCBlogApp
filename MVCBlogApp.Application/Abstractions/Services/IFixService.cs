using MVCBlogApp.Application.Features.Commands.Fix.FixBmh.FixBmhCreate;
using MVCBlogApp.Application.Features.Commands.Fix.FixBmh.FixBmhDelete;
using MVCBlogApp.Application.Features.Commands.Fix.FixBmh.FixBmhUpdate;
using MVCBlogApp.Application.Features.Queries.Fix.FixBmh.GetAllFixBmhs;
using MVCBlogApp.Application.Features.Queries.Fix.FixBmh.GetByIdFixBmh;
using MVCBlogApp.Application.Features.Queries.Fix.FixBmh.GetFixBmhCreateItems;

namespace MVCBlogApp.Application.Abstractions.Services
{
    public interface IFixService
    {
        #region FixBmh

        Task<GetFixBmhCreateItemsQueryResponse> GetFixBmhCreateItemsAsync();
        Task<GetAllFixBmhsQueryResponse> GetAllFixBmhsAsync();
        Task<FixBmhCreateCommandResponse> FixBmhCreateAsync(FixBmhCreateCommandRequest request);
        Task<GetByIdFixBmhQueryResponse> GetByIdFixBmhAsync(int id);
        Task<FixBmhUpdateCommandResponse> FixBmhUpdateAsync(FixBmhUpdateCommandRequest request);
        Task<FixBmhDeleteCommandResponse> FixBmhDeleteAsync(int id);

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
