using MVCBlogApp.Application.Features.Commands.Doctor.Day.DayCreate;
using MVCBlogApp.Application.Features.Commands.Doctor.Day.DayDelete;
using MVCBlogApp.Application.Features.Commands.Doctor.Day.DayUpdate;
using MVCBlogApp.Application.Features.Commands.Doctor.DietList.DietListCreate;
using MVCBlogApp.Application.Features.Commands.Doctor.DietList.DietListDelete;
using MVCBlogApp.Application.Features.Commands.Doctor.DietList.DietListUpdate;
using MVCBlogApp.Application.Features.Commands.Doctor.Examination.ExaminationCreate;
using MVCBlogApp.Application.Features.Commands.Doctor.Examination.ExaminationDelete;
using MVCBlogApp.Application.Features.Commands.Doctor.Examination.ExaminationUpdate;
using MVCBlogApp.Application.Features.Commands.Doctor.Meal.MealCreate;
using MVCBlogApp.Application.Features.Commands.Doctor.Meal.MealDelete;
using MVCBlogApp.Application.Features.Commands.Doctor.Meal.MealUpdate;
using MVCBlogApp.Application.Features.Queries.Doctor.Day.GetAllDays;
using MVCBlogApp.Application.Features.Queries.Doctor.Day.GetByIdDay;
using MVCBlogApp.Application.Features.Queries.Doctor.DietList.GetAllDietList;
using MVCBlogApp.Application.Features.Queries.Doctor.DietList.GetByIdDietList;
using MVCBlogApp.Application.Features.Queries.Doctor.DietList.GetDietListCreateItems;
using MVCBlogApp.Application.Features.Queries.Doctor.Examination.GetAllExamination;
using MVCBlogApp.Application.Features.Queries.Doctor.Examination.GetByIdExamination;
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

        #region DietList

        Task<GetDietListCreateItemsQueryResponse> GetDietListCreateItemsAsync();
        Task<GetAllDietListQueryResponse> GetAllDietListAsync();
        Task<DietListCreateCommandResponse> DietListCreateAsync(DietListCreateCommandRequest request);
        Task<GetByIdDietListQueryResponse> GetByIdDietListAsync(int id);
        Task<DietListUpdateCommandResponse> DietListUpdateAsync(DietListUpdateCommandRequest request);
        Task<DietListDeleteCommandResponse> DietListDeleteAsync(int id);

        #endregion

        #region Examination

        Task<ExaminationCreateCommandResponse> ExaminationCreateAsync(ExaminationCreateCommandRequest request);
        Task<GetAllExaminationQueryResponse> GetAllExaminationAsync();
        Task<GetByIdExaminationQueryResponse> GetByIdExaminationAsync(int id);
        Task<ExaminationUpdateCommandResponse> ExaminationUpdateAsync(ExaminationUpdateCommandRequest request);
        Task<ExaminationDeleteCommandResponse> ExaminationDeleteAsync(int id);

        #endregion
    }
}
