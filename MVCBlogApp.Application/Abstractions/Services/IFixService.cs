using MVCBlogApp.Application.Features.Commands.Fix.FixBmh.FixBmhCreate;
using MVCBlogApp.Application.Features.Commands.Fix.FixBmh.FixBmhDelete;
using MVCBlogApp.Application.Features.Commands.Fix.FixBmh.FixBmhUpdate;
using MVCBlogApp.Application.Features.Commands.Fix.FixBMI.FixBMICreate;
using MVCBlogApp.Application.Features.Commands.Fix.FixBMI.FixBMIDelete;
using MVCBlogApp.Application.Features.Commands.Fix.FixBMI.FixBMIUpdate;
using MVCBlogApp.Application.Features.Commands.Fix.FixCalorieSch.FixCalorieSchCreate;
using MVCBlogApp.Application.Features.Commands.Fix.FixCalorieSch.FixCalorieSchDelete;
using MVCBlogApp.Application.Features.Commands.Fix.FixCalorieSch.FixCalorieSchUpdate;
using MVCBlogApp.Application.Features.Commands.Fix.FixFeedPyramid.FixFeedPyramidCreate;
using MVCBlogApp.Application.Features.Queries.Fix.FixBmh.GetAllFixBmhs;
using MVCBlogApp.Application.Features.Queries.Fix.FixBmh.GetByIdFixBmh;
using MVCBlogApp.Application.Features.Queries.Fix.FixBmh.GetFixBmhCreateItems;
using MVCBlogApp.Application.Features.Queries.Fix.FixBMI.GetAllFixBMI;
using MVCBlogApp.Application.Features.Queries.Fix.FixBMI.GetByIdFixBMI;
using MVCBlogApp.Application.Features.Queries.Fix.FixBMI.GetFixBMICreateItems;
using MVCBlogApp.Application.Features.Queries.Fix.FixCalorieSch.GetAllFixCalorieSch;
using MVCBlogApp.Application.Features.Queries.Fix.FixCalorieSch.GetByIdFixCalorieSch;
using MVCBlogApp.Application.Features.Queries.Fix.FixCalorieSch.GetFixCalorieSchCreateItems;
using MVCBlogApp.Application.Features.Queries.Fix.FixFeedPyramid.GetAllFixFeedPyramid;
using MVCBlogApp.Application.Features.Queries.Fix.FixFeedPyramid.GetFixFeedPyramidCreateItems;

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

        Task<GetFixBMICreateItemsQueryResponse> GetFixBMICreateItemsAsync();
        Task<GetAllFixBMIQueryResponse> GetAllFixBMIAsync();
        Task<FixBMICreateCommandResponse> FixBMICreateAsync(FixBMICreateCommandRequest request);
        Task<GetByIdFixBMIQueryResponse> GetByIdFixBMIAsync(int id);
        Task<FixBMIUpdateCommandResponse> FixBMIUpdateAsync(FixBMIUpdateCommandRequest request);
        Task<FixBMIDeleteCommandResponse> FixBMIDeleteAsync(int id);

        #endregion

        #region FixCalorieSch

        Task<GetFixCalorieSchCreateItemsQueryResponse> GetFixCalorieSchCreateItemsAsync();
        Task<GetAllFixCalorieSchQueryResponse> GetAllFixCalorieSchAsync();
        Task<FixCalorieSchCreateCommandResponse> FixCalorieSchCreateAsync(FixCalorieSchCreateCommandRequest request);
        Task<GetByIdFixCalorieSchQueryResponse> GetByIdFixCalorieSchAsync(int id);
        Task<FixCalorieSchUpdateCommandResponse> FixCalorieSchUpdateAsync(FixCalorieSchUpdateCommandRequest request);
        Task<FixCalorieSchDeleteCommandResponse> FixCalorieSchDeleteAsync(int id);

        #endregion

        #region FixFeedPyramid

        Task<GetFixFeedPyramidCreateItemsQueryResponse> GetFixFeedPyramidCreateItemsAsync();
        Task<GetAllFixFeedPyramidQueryResponse> GetAllFixFeedPyramidAsync();
        Task<FixFeedPyramidCreateCommandResponse> FixFeedPyramidCreateAsync(FixFeedPyramidCreateCommandRequest request);

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
