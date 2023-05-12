using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Doctor.DietList.DietListDelete
{
    public class DietListDeleteCommandHandler : IRequestHandler<DietListDeleteCommandRequest, DietListDeleteCommandResponse>
    {
        private readonly IDoctorGeneralOptionsService _generalOptionsService;

        public DietListDeleteCommandHandler(IDoctorGeneralOptionsService generalOptionsService)
        {
            _generalOptionsService = generalOptionsService;
        }

        public async Task<DietListDeleteCommandResponse> Handle(DietListDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _generalOptionsService.DietListDeleteAsync(request.Id);
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
