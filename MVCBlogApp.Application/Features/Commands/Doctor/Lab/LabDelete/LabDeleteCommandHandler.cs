using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Doctor.Lab.LabDelete
{
    public class LabDeleteCommandHandler : IRequestHandler<LabDeleteCommandRequest, LabDeleteCommandResponse>
    {
        private readonly IDoctorGeneralOptionsService _optionsService;

        public LabDeleteCommandHandler(IDoctorGeneralOptionsService optionsService)
        {
            _optionsService = optionsService;
        }

        public async Task<LabDeleteCommandResponse> Handle(LabDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _optionsService.LabDeleteAsync(request.Id);
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
