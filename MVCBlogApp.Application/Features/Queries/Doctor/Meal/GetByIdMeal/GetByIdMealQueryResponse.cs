using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.Doctor.Meal.GetByIdMeal
{
    public class GetByIdMealQueryResponse
    {
        public VM_Meal? Meal { get; set; }
        public string? Message { get; set; }
        public bool State { get; set; }
    }
}