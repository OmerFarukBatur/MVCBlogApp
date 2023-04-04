using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Fix.FixCalorieSch.FixCalorieSchDelete
{
    public class FixCalorieSchDeleteCommandHandler : IRequestHandler<FixCalorieSchDeleteCommandRequest, FixCalorieSchDeleteCommandResponse>
    {
        private readonly IFixService _fixService;

        public FixCalorieSchDeleteCommandHandler(IFixService fixService)
        {
            _fixService = fixService;
        }

        public async Task<FixCalorieSchDeleteCommandResponse> Handle(FixCalorieSchDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _fixService.FixCalorieSchDeleteAsync(request.Id);
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
