using MediatR;

namespace MVCBlogApp.Application.Features.Commands.Doctor.Meal.MealDelete
{
    public class MealDeleteCommandRequest : IRequest<MealDeleteCommandResponse>
    {
        public int Id { get; set; }
    }
}