using MediatR;

namespace MVCBlogApp.Application.Features.Commands.Doctor.Meal.MealCreate
{
    public class MealCreateCommandRequest : IRequest<MealCreateCommandResponse>
    {
        public string MealName { get; set; }
    }
}