using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Doctor.Day.DayUpdate
{
    public class DayUpdateCommandHandler : IRequestHandler<DayUpdateCommandRequest, DayUpdateCommandResponse>
    {
        private readonly IDoctorGeneralOptionsService _optionsService;

        public DayUpdateCommandHandler(IDoctorGeneralOptionsService optionsService)
        {
            _optionsService = optionsService;
        }

        public async Task<DayUpdateCommandResponse> Handle(DayUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.DayName != "" && request.DayName != null && request.DayName.Length > 3 && request.DayName.Length < 51)
            {
                return await _optionsService.DayUpdateAsync(request);
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
