using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Doctor.Day.DayCreate
{
    public class DayCreateCommandHandler : IRequestHandler<DayCreateCommandRequest, DayCreateCommandResponse>
    {
        private readonly IDoctorGeneralOptionsService _optionsService;

        public DayCreateCommandHandler(IDoctorGeneralOptionsService optionsService)
        {
            _optionsService = optionsService;
        }

        public async Task<DayCreateCommandResponse> Handle(DayCreateCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.DayName != "" && request.DayName != null && request.DayName.Length > 3 && request.DayName.Length <51)
            {
                return await _optionsService.DayCreateAsync(request);
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
