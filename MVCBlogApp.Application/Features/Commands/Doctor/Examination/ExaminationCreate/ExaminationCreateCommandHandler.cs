using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Doctor.Examination.ExaminationCreate
{
    public class ExaminationCreateCommandHandler : IRequestHandler<ExaminationCreateCommandRequest, ExaminationCreateCommandResponse>
    {
        private readonly IDoctorGeneralOptionsService _generalOptionsService;

        public ExaminationCreateCommandHandler(IDoctorGeneralOptionsService generalOptionsService)
        {
            _generalOptionsService = generalOptionsService;
        }

        public async Task<ExaminationCreateCommandResponse> Handle(ExaminationCreateCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.ExaminatioName != "" && request.ExaminatioName != null && request.ExaminatioName.Length > 1 && request.ExaminatioName.Length < 51)
            {
                return await _generalOptionsService.ExaminationCreateAsync(request);
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
