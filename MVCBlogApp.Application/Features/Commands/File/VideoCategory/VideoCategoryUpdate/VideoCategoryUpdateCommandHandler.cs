using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.File.VideoCategory.VideoCategoryUpdate
{
    public class VideoCategoryUpdateCommandHandler : IRequestHandler<VideoCategoryUpdateCommandRequest, VideoCategoryUpdateCommandResponse>
    {
        private readonly IFileProcessService _fileProcessService;

        public VideoCategoryUpdateCommandHandler(IFileProcessService fileProcessService)
        {
            _fileProcessService = fileProcessService;
        }

        public async Task<VideoCategoryUpdateCommandResponse> Handle(VideoCategoryUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            VideoCategoryUpdateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);
            
            if (validation.IsValid)
            {
                return await _fileProcessService.VideoCategoryUpdateAsync(request);
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
