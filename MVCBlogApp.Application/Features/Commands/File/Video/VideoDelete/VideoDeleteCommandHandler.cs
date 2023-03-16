using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.File.Video.VideoDelete
{
    public class VideoDeleteCommandHandler : IRequestHandler<VideoDeleteCommandRequest, VideoDeleteCommandResponse>
    {
        private readonly IFileProcessService _fileProcessService;

        public VideoDeleteCommandHandler(IFileProcessService fileProcessService)
        {
            _fileProcessService = fileProcessService;
        }

        public async Task<VideoDeleteCommandResponse> Handle(VideoDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _fileProcessService.VideoDeleteAsync(request.Id);
            }
            else
            {
                return new()
                {                    
                    Message = "Lütfen geçerli değerler giriniz.",
                    State = false
                };
            }
        }
    }
}
