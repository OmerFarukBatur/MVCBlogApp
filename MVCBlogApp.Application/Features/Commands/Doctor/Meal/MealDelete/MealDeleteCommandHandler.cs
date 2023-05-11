using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Doctor.Meal.MealDelete
{
    public class MealDeleteCommandHandler : IRequestHandler<MealDeleteCommandRequest, MealDeleteCommandResponse>
    {
        private readonly IDoctorGeneralOptionsService _optionsService;

        public MealDeleteCommandHandler(IDoctorGeneralOptionsService optionsService)
        {
            _optionsService = optionsService;
        }

        public async Task<MealDeleteCommandResponse> Handle(MealDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _optionsService.MealDeleteAsync(request.Id);
            }
            else
            {
                return new()
                {
                    Message = "Kayıt bulunamamıştır.",
                    State = false
                };
            }
        }
    }
}
