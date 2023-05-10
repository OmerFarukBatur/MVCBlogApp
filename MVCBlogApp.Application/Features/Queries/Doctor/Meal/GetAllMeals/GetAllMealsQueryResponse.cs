using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.Doctor.Meal.GetAllMeals
{
    public class GetAllMealsQueryResponse
    {
        public List<VM_Meal> Meals { get; set; }
    }
}