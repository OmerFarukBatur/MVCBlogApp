using MediatR;

namespace MVCBlogApp.Application.Features.Commands.Doctor.Meal.MealUpdate
{
    public class MealUpdateCommandRequest : IRequest<MealUpdateCommandResponse>
    {
        public int Id { get; set; }
        public string MealName { get; set; }
    }
}