using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Doctor.Meal.GetAllMeals
{
    public class GetAllMealsQueryHandler : IRequestHandler<GetAllMealsQueryRequest, GetAllMealsQueryResponse>
    {
        private readonly IDoctorGeneralOptionsService _optionsService;

        public GetAllMealsQueryHandler(IDoctorGeneralOptionsService optionsService)
        {
            _optionsService = optionsService;
        }

        public async Task<GetAllMealsQueryResponse> Handle(GetAllMealsQueryRequest request, CancellationToken cancellationToken)
        {
            return await _optionsService.GetAllMealsAsync();
        }
    }
}
