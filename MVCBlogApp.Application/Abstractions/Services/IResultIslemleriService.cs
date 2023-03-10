using MVCBlogApp.Application.Features.Commands.Result.ResultBMhs.ResultBMhsCreate;
using MVCBlogApp.Application.Features.Commands.Result.ResultBMhs.ResultBMhsDelete;
using MVCBlogApp.Application.Features.Commands.Result.ResultBMhs.ResultBMhsUpdate;
using MVCBlogApp.Application.Features.Queries.Result.ResultBMhs.GetAllResultBMhs;
using MVCBlogApp.Application.Features.Queries.Result.ResultBMhs.GetByIdResultBMhs;

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



        #endregion

        #region ResultOptimums



        #endregion

        #region ResultPulses



        #endregion

    }
}
