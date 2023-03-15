using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.File.VideoCategory.VideoCategoryCreate
{
    public class VideoCategoryCreateCommandHandler : IRequestHandler<VideoCategoryCreateCommandRequest, VideoCategoryCreateCommandResponse>
    {
        private readonly IFileProcessService _fileProcessService;

        public VideoCategoryCreateCommandHandler(IFileProcessService fileProcessService)
        {
            _fileProcessService = fileProcessService;
        }

        public async Task<VideoCategoryCreateCommandResponse> Handle(VideoCategoryCreateCommandRequest request, CancellationToken cancellationToken)
        {
            VideoCategoryCreateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);

            if (validation.IsValid)
            {
                return await _fileProcessService.VideoCategoryCreateAsync(request);
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
