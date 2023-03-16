using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.File.Video.VideoCreate
{
    public class VideoCreateCommandHandler : IRequestHandler<VideoCreateCommandRequest, VideoCreateCommandResponse>
    {
        private readonly IFileProcessService _fileProcessService;

        public VideoCreateCommandHandler(IFileProcessService fileProcessService)
        {
            _fileProcessService = fileProcessService;
        }

        public async Task<VideoCreateCommandResponse> Handle(VideoCreateCommandRequest request, CancellationToken cancellationToken)
        {
            VideoCreateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);

            if (validation.IsValid)
            {
                return await _fileProcessService.VideoCreateAsync(request);
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
