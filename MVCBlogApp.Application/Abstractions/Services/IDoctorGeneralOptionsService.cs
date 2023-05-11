using MVCBlogApp.Application.Features.Commands.Doctor.Day.DayCreate;
using MVCBlogApp.Application.Features.Commands.Doctor.Day.DayDelete;
using MVCBlogApp.Application.Features.Commands.Doctor.Day.DayUpdate;
using MVCBlogApp.Application.Features.Commands.Doctor.Meal.MealCreate;
using MVCBlogApp.Application.Features.Commands.Doctor.Meal.MealDelete;
using MVCBlogApp.Application.Features.Commands.Doctor.Meal.MealUpdate;
using MVCBlogApp.Application.Features.Queries.Doctor.Day.GetAllDays;
using MVCBlogApp.Application.Features.Queries.Doctor.Day.GetByIdDay;
using MVCBlogApp.Application.Features.Queries.Doctor.Meal.GetAllMeals;
using MVCBlogApp.Application.Features.Queries.Doctor.Meal.GetByIdMeal;

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

        Task<GetAllMealsQueryResponse> GetAllMealsAsync();
        Task<MealCreateCommandResponse> MealCreateAsync(MealCreateCommandRequest request);
        Task<GetByIdMealQueryResponse> GetByIdMealAsync(int id);
        Task<MealUpdateCommandResponse> MealUpdateAsync(MealUpdateCommandRequest request);
        Task<MealDeleteCommandResponse> MealDeleteAsync(int id);

        #endregion
    }
}
