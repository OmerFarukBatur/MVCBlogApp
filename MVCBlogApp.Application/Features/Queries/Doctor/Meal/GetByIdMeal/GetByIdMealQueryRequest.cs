using MediatR;

namespace MVCBlogApp.Application.Features.Queries.Doctor.Meal.GetByIdMeal
{
    public class GetByIdMealQueryRequest : IRequest<GetByIdMealQueryResponse>
    {
        public int Id { get; set; }
    }
}