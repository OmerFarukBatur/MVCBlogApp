using MVCBlogApp.Application.Features.Commands.Doctor.Day.DayCreate;
using MVCBlogApp.Application.Features.Queries.Doctor.Day.GetAllDays;

namespace MVCBlogApp.Application.Abstractions.Services
{
    public interface IDoctorGeneralOptionsService
    {
        #region Day

        Task<GetAllDaysQueryResponse> GetAllDaysAsync();
        Task<DayCreateCommandResponse> DayCreateAsync(DayCreateCommandRequest request);

        #endregion

        #region Meal



        #endregion
    }
}
