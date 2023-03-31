using MVCBlogApp.Application.Features.Queries.Calc.CalcBmhs.GetAllCalcBmhs;
using MVCBlogApp.Application.Features.Queries.Calc.CalcBMIs.GetAllCalcBMIs;
using MVCBlogApp.Application.Features.Queries.Calc.CalcOptimums.GetAllCalcOptimums;
using MVCBlogApp.Application.Features.Queries.Calc.CalcPulses.GetAllCalcPulses;

namespace MVCBlogApp.Application.Abstractions.Services
{
    public interface ICalcService
    {

        #region CalcBmhs

        Task<GetAllCalcBmhsQueryResponse> GetAllCalcBmhsAsync();

        #endregion

        #region CalcBMIs

        Task<GetAllCalcBMIsQueryResponse> GetAllCalcBMIsAsync();

        #endregion

        #region CalcOptimums

        Task<GetAllCalcOptimumsQueryResponse> GetAllCalcOptimumsAsync();

        #endregion

        #region CalcPulses

        Task<GetAllCalcPulsesQueryResponse> GetAllCalcPulsesAsync();

        #endregion

    }
}
