using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.File.Banner.BannerDelete
{
    public class BannerDeleteCommandHandler : IRequestHandler<BannerDeleteCommandRequest, BannerDeleteCommandResponse>
    {
        private readonly IFileProcessService _fileProcessService;

        public BannerDeleteCommandHandler(IFileProcessService fileProcessService)
        {
            _fileProcessService = fileProcessService;
        }

        public async Task<BannerDeleteCommandResponse> Handle(BannerDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _fileProcessService.BannerDeleteAsync(request.Id);
            }
            else
            {
                return new()
                {
                    State = false,
                    Message = "Kayıt bulunamamıştır."
                };
            }
        }
    }
}
