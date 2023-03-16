using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.File.Image.ImageUpload
{
    public class ImageUploadCommandHandler : IRequestHandler<ImageUploadCommandRequest, ImageUploadCommandResponse>
    {
        private readonly IFileProcessService _fileProcessService;

        public ImageUploadCommandHandler(IFileProcessService fileProcessService)
        {
            _fileProcessService = fileProcessService;
        }

        public async Task<ImageUploadCommandResponse> Handle(ImageUploadCommandRequest request, CancellationToken cancellationToken)
        {
            ImageUploadCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);

            if (validation.IsValid)
            {
                return await _fileProcessService.ImageUploadAsync(request);
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
