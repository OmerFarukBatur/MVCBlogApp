using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Doctor.Meal.MealUpdate
{
    public class MealUpdateCommandHandler : IRequestHandler<MealUpdateCommandRequest, MealUpdateCommandResponse>
    {
        private readonly IDoctorGeneralOptionsService _generalOptionsService;

        public MealUpdateCommandHandler(IDoctorGeneralOptionsService generalOptionsService)
        {
            _generalOptionsService = generalOptionsService;
        }

        public async Task<MealUpdateCommandResponse> Handle(MealUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.MealName != "" && request.MealName != null && request.MealName.Length > 1 && request.MealName.Length < 251)
            {
                return await _generalOptionsService.MealUpdateAsync(request);
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
