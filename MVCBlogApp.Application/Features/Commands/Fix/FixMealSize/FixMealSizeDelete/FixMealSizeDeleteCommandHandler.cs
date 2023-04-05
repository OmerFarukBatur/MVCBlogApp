using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Fix.FixMealSize.FixMealSizeDelete
{
    public class FixMealSizeDeleteCommandHandler : IRequestHandler<FixMealSizeDeleteCommandRequest, FixMealSizeDeleteCommandResponse>
    {
        private readonly IFixService _fixService;

        public FixMealSizeDeleteCommandHandler(IFixService fixService)
        {
            _fixService = fixService;
        }

        public async Task<FixMealSizeDeleteCommandResponse> Handle(FixMealSizeDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _fixService.FixMealSizeDeleteAsync(request.Id);
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
