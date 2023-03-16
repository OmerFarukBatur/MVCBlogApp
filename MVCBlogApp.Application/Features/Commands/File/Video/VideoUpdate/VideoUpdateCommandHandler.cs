using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.File.Video.VideoUpdate
{
    public class VideoUpdateCommandHandler : IRequestHandler<VideoUpdateCommandRequest, VideoUpdateCommandResponse>
    {
        private readonly IFileProcessService _fileProcessService;

        public VideoUpdateCommandHandler(IFileProcessService fileProcessService)
        {
            _fileProcessService = fileProcessService;
        }

        public async Task<VideoUpdateCommandResponse> Handle(VideoUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            VideoUpdateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);

            if (validation.IsValid)
            {
                return await _fileProcessService.VideoUpdateAsync(request);
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
