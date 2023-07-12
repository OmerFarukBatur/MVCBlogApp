using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.IUHome.UploadImage
{
    public class UploadImageCommandHandler : IRequestHandler<UploadImageCommandRequest, UploadImageCommandResponse>
    {
        private readonly IUIHomeService _uiHomeService;

        public UploadImageCommandHandler(IUIHomeService uiHomeService)
        {
            _uiHomeService = uiHomeService;
        }

        public async Task<UploadImageCommandResponse> Handle(UploadImageCommandRequest request, CancellationToken cancellationToken)
        {
            return await _uiHomeService.UploadImageAsync(request);
        }
    }
}
