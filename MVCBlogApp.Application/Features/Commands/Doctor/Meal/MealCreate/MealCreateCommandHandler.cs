using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Doctor.Meal.MealCreate
{
    public class MealCreateCommandHandler : IRequestHandler<MealCreateCommandRequest, MealCreateCommandResponse>
    {
        private readonly IDoctorGeneralOptionsService _optionsService;

        public MealCreateCommandHandler(IDoctorGeneralOptionsService optionsService)
        {
            _optionsService = optionsService;
        }

        public async Task<MealCreateCommandResponse> Handle(MealCreateCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.MealName != "" && request.MealName != null && request.MealName.Length > 1 && request.MealName.Length < 251)
            {
                return await _optionsService.MealCreateAsync(request);
            }
            else
            {
                return new()
                {
                    Message = "Lütfen alanları geçerli değerlerle doldurunuz.",
                    State = false
                };
            }
        }
    }
}
