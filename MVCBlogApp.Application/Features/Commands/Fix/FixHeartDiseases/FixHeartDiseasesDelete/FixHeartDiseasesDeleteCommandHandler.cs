using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Fix.FixHeartDiseases.FixHeartDiseasesDelete
{
    public class FixHeartDiseasesDeleteCommandHandler : IRequestHandler<FixHeartDiseasesDeleteCommandRequest, FixHeartDiseasesDeleteCommandResponse>
    {
        private readonly IFixService _fixService;

        public FixHeartDiseasesDeleteCommandHandler(IFixService fixService)
        {
            _fixService = fixService;
        }

        public async Task<FixHeartDiseasesDeleteCommandResponse> Handle(FixHeartDiseasesDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _fixService.FixHeartDiseasesDeleteAsync(request.Id);
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
