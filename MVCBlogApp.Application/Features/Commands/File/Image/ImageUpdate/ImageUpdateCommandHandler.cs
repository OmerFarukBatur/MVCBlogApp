using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.File.Image.ImageUpdate
{
    public class ImageUpdateCommandHandler : IRequestHandler<ImageUpdateCommandRequest, ImageUpdateCommandResponse>
    {
        private readonly IFileProcessService _fileProcessService;

        public ImageUpdateCommandHandler(IFileProcessService fileProcessService)
        {
            _fileProcessService = fileProcessService;
        }

        public async Task<ImageUpdateCommandResponse> Handle(ImageUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            ImageUpdateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);
            if (validation.IsValid)
            {
                return await _fileProcessService.ImageUpdateAsync(request);
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
