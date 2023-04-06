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
using MVCBlogApp.Application.Features.Commands.Fix.FixFeedPyramid.FixFeedPyramidDelete;
using MVCBlogApp.Application.Features.Commands.Fix.FixFeedPyramid.FixFeedPyramidUpdate;
using MVCBlogApp.Application.Features.Commands.Fix.FixHeartDiseases.FixHeartDiseasesCreate;
using MVCBlogApp.Application.Features.Commands.Fix.FixHeartDiseases.FixHeartDiseasesDelete;
using MVCBlogApp.Application.Features.Commands.Fix.FixHeartDiseases.FixHeartDiseasesUpdate;
using MVCBlogApp.Application.Features.Commands.Fix.FixMealSize.FixMealSizeCreate;
using MVCBlogApp.Application.Features.Commands.Fix.FixMealSize.FixMealSizeDelete;
using MVCBlogApp.Application.Features.Commands.Fix.FixMealSize.FixMealSizeUpdate;
using MVCBlogApp.Application.Features.Commands.Fix.FixOptimum.FixOptimumCreate;
using MVCBlogApp.Application.Features.Commands.Fix.FixOptimum.FixOptimumDelete;
using MVCBlogApp.Application.Features.Commands.Fix.FixOptimum.FixOptimumUpdate;
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
using MVCBlogApp.Application.Features.Queries.Fix.FixFeedPyramid.GetByIdFixFeedPyramid;
using MVCBlogApp.Application.Features.Queries.Fix.FixFeedPyramid.GetFixFeedPyramidCreateItems;
using MVCBlogApp.Application.Features.Queries.Fix.FixHeartDiseases.GetAllFixHeartDiseases;
using MVCBlogApp.Application.Features.Queries.Fix.FixHeartDiseases.GetByIdFixHeartDiseases;
using MVCBlogApp.Application.Features.Queries.Fix.FixHeartDiseases.GetFixHeartDiseasesCreateItems;
using MVCBlogApp.Application.Features.Queries.Fix.FixMealSize.GetAllFixMealSize;
using MVCBlogApp.Application.Features.Queries.Fix.FixMealSize.GetByIdFixMealSize;
using MVCBlogApp.Application.Features.Queries.Fix.FixMealSize.GetFixMealSizeCreateItems;
using MVCBlogApp.Application.Features.Queries.Fix.FixOptimum.GetAllFixOptimum;
using MVCBlogApp.Application.Features.Queries.Fix.FixOptimum.GetByIdFixOptimum;
using MVCBlogApp.Application.Features.Queries.Fix.FixOptimum.GetFixOptimumCreateItems;

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
        Task<GetByIdFixFeedPyramidQueryResponse> GetByIdFixFeedPyramidAsync(int id);
        Task<FixFeedPyramidUpdateCommandResponse> FixFeedPyramidUpdateAsync(FixFeedPyramidUpdateCommandRequest request);
        Task<FixFeedPyramidDeleteCommandResponse> FixFeedPyramidDeleteAsync(int id);

        #endregion

        #region FixHeartDiseases

        Task<GetFixHeartDiseasesCreateItemsQueryResponse> GetFixHeartDiseasesCreateItemsAsync();
        Task<GetAllFixHeartDiseasesQueryResponse> GetAllFixHeartDiseasesAsync();
        Task<FixHeartDiseasesCreateCommandResponse> FixHeartDiseasesCreateAsync(FixHeartDiseasesCreateCommandRequest request);
        Task<GetByIdFixHeartDiseasesQueryResponse> GetByIdFixHeartDiseasesAsync(int id);
        Task<FixHeartDiseasesUpdateCommandResponse> FixHeartDiseasesUpdateAsync(FixHeartDiseasesUpdateCommandRequest request);
        Task<FixHeartDiseasesDeleteCommandResponse> FixHeartDiseasesDeleteAsync(int id);

        #endregion

        #region FixMealSize

        Task<GetFixMealSizeCreateItemsQueryResponse> GetFixMealSizeCreateItemsAsync();
        Task<GetAllFixMealSizeQueryResponse> GetAllFixMealSizeAsync();
        Task<FixMealSizeCreateCommandResponse> FixMealSizeCreateAsync(FixMealSizeCreateCommandRequest request);
        Task<GetByIdFixMealSizeQueryResponse> GetByIdFixMealSizeAsync(int id);
        Task<FixMealSizeUpdateCommandResponse> FixMealSizeUpdateAsync(FixMealSizeUpdateCommandRequest request); 
        Task<FixMealSizeDeleteCommandResponse> FixMealSizeDeleteAsync(int id);

        #endregion

        #region FixOptimum

        Task<GetFixOptimumCreateItemsQueryResponse> GetFixOptimumCreateItemsAsync();
        Task<GetAllFixOptimumQueryResponse> GetAllFixOptimumAsync();
        Task<FixOptimumCreateCommandResponse> FixOptimumCreateAsync(FixOptimumCreateCommandRequest request);
        Task<GetByIdFixOptimumQueryResponse> GetByIdFixOptimumAsync(int id); 
        Task<FixOptimumUpdateCommandResponse> FixOptimumUpdateAsync(FixOptimumUpdateCommandRequest request);
        Task<FixOptimumDeleteCommandResponse> FixOptimumDeleteAsync(int id);

        #endregion

        #region FixPulse
        #endregion
    }
}
