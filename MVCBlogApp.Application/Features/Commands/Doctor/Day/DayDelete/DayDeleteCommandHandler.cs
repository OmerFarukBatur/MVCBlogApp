using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Doctor.Day.DayDelete
{
    public class DayDeleteCommandHandler : IRequestHandler<DayDeleteCommandRequest, DayDeleteCommandResponse>
    {
        private readonly IDoctorGeneralOptionsService _optionsService;

        public DayDeleteCommandHandler(IDoctorGeneralOptionsService optionsService)
        {
            _optionsService = optionsService;
        }

        public async Task<DayDeleteCommandResponse> Handle(DayDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _optionsService.DayDeleteAsync(request.Id);
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
