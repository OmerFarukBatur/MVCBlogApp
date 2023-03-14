﻿using MVCBlogApp.Application.Features.Commands.Result.ResultBMhs.ResultBMhsCreate;
using MVCBlogApp.Application.Features.Commands.Result.ResultBMhs.ResultBMhsDelete;
using MVCBlogApp.Application.Features.Commands.Result.ResultBMhs.ResultBMhsUpdate;
using MVCBlogApp.Application.Features.Commands.Result.ResultBMIs.ResultBMIsCreate;
using MVCBlogApp.Application.Features.Commands.Result.ResultBMIs.ResultBMIsDelete;
using MVCBlogApp.Application.Features.Commands.Result.ResultBMIs.ResultBMIsUpdate;
using MVCBlogApp.Application.Features.Commands.Result.ResultOptimums.ResultOptimumsCreate;
using MVCBlogApp.Application.Features.Commands.Result.ResultOptimums.ResultOptimumsDelete;
using MVCBlogApp.Application.Features.Commands.Result.ResultOptimums.ResultOptimumsUpdate;
using MVCBlogApp.Application.Features.Queries.Result.ResultBMhs.GetAllResultBMhs;
using MVCBlogApp.Application.Features.Queries.Result.ResultBMhs.GetByIdResultBMhs;
using MVCBlogApp.Application.Features.Queries.Result.ResultBMIs.GetAllResultBMI;
using MVCBlogApp.Application.Features.Queries.Result.ResultBMIs.GetByIdResultBMI;
using MVCBlogApp.Application.Features.Queries.Result.ResultOptimums.GetAllResultOptimums;
using MVCBlogApp.Application.Features.Queries.Result.ResultOptimums.GetByIdResultOptimum;

namespace MVCBlogApp.Application.Abstractions.Services
{
    public interface IResultIslemleriService
    {

        #region ResultBMhs

        Task<ResultBMhsCreateCommandResponse> ResultBMhsCreateAsync(ResultBMhsCreateCommandRequest request);
        Task<GetAllResultBMhsQueryResponse> GetAllResultBMhsAsync();
        Task<GetByIdResultBMhsQueryResponse> GetByIdResultBMhsAsync(int id);
        Task<ResultBMhsUpdateCommandResponse> ResultBMhsUpdateAsync(ResultBMhsUpdateCommandRequest request);
        Task<ResultBMhsDeleteCommandResponse> ResultBMhsDeleteAsync(int id);

        #endregion

        #region ResultBMIs

        Task<GetAllResultBMIQueryResponse> GetAllResultBMIAsync();
        Task<ResultBMIsCreateCommandResponse> ResultBMIsCreateAsync(ResultBMIsCreateCommandRequest request);
        Task<GetByIdResultBMIQueryResponse> GetByIdResultBMIAsync(int id);
        Task<ResultBMIsUpdateCommandResponse> ResultBMIsUpdateAsync(ResultBMIsUpdateCommandRequest request);
        Task<ResultBMIsDeleteCommandResponse> ResultBMIsDeleteAsync(int id);

        #endregion

        #region ResultOptimums

        Task<GetAllResultOptimumsQueryResponse> GetAllResultOptimumsAsync();
        Task<ResultOptimumsCreateCommandResponse> ResultOptimumsCreateAsync(ResultOptimumsCreateCommandRequest request);
        Task<GetByIdResultOptimumQueryResponse> GetByIdResultOptimumAsync(int id);
        Task<ResultOptimumsUpdateCommandResponse> ResultOptimumsUpdateAsync(ResultOptimumsUpdateCommandRequest request);
        Task<ResultOptimumsDeleteCommandResponse> ResultOptimumsDeleteAsync(int id);

        #endregion

        #region ResultPulses



        #endregion

    }
}
