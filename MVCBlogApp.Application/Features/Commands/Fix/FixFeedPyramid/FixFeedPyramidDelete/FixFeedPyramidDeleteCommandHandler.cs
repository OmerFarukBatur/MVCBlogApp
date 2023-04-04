using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Fix.FixFeedPyramid.FixFeedPyramidDelete
{
    public class FixFeedPyramidDeleteCommandHandler : IRequestHandler<FixFeedPyramidDeleteCommandRequest, FixFeedPyramidDeleteCommandResponse>
    {
        private readonly IFixService _fixService;

        public FixFeedPyramidDeleteCommandHandler(IFixService fixService)
        {
            _fixService = fixService;
        }

        public async Task<FixFeedPyramidDeleteCommandResponse> Handle(FixFeedPyramidDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _fixService.FixFeedPyramidDeleteAsync(request.Id);
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
