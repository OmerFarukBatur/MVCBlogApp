using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Doctor.Examination.ExaminationUpdate
{
    public class ExaminationUpdateCommandHandler : IRequestHandler<ExaminationUpdateCommandRequest, ExaminationUpdateCommandResponse>
    {
        private readonly IDoctorGeneralOptionsService _optionsService;

        public ExaminationUpdateCommandHandler(IDoctorGeneralOptionsService optionsService)
        {
            _optionsService = optionsService;
        }

        public async Task<ExaminationUpdateCommandResponse> Handle(ExaminationUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.ExaminatioName != "" && request.ExaminatioName != null && request.ExaminatioName.Length > 1 && request.ExaminatioName.Length < 51)
            {
                return await _optionsService.ExaminationUpdateAsync(request);
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
