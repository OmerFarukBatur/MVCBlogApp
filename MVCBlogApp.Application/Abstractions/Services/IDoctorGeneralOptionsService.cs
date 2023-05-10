using MVCBlogApp.Application.Features.Commands.Doctor.Day.DayCreate;
using MVCBlogApp.Application.Features.Commands.Doctor.Day.DayDelete;
using MVCBlogApp.Application.Features.Commands.Doctor.Day.DayUpdate;
using MVCBlogApp.Application.Features.Queries.Doctor.Day.GetAllDays;
using MVCBlogApp.Application.Features.Queries.Doctor.Day.GetByIdDay;

namespace MVCBlogApp.Application.Abstractions.Services
{
    public interface IDoctorGeneralOptionsService
    {
        #region Day

        Task<GetAllDaysQueryResponse> GetAllDaysAsync();
        Task<DayCreateCommandResponse> DayCreateAsync(DayCreateCommandRequest request);
        Task<GetByIdDayQueryResponse> GetByIdDayAsync(int id);
        Task<DayUpdateCommandResponse> DayUpdateAsync(DayUpdateCommandRequest request);
        Task<DayDeleteCommandResponse> DayDeleteAsync(int id);

        #endregion

        #region Meal



        #endregion
    }
}
