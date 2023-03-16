using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.File.Image.ImageDelete
{
    public class ImageDeleteCommandHandler : IRequestHandler<ImageDeleteCommandRequest, ImageDeleteCommandResponse>
    {
        private readonly IFileProcessService _fileProcessService;

        public ImageDeleteCommandHandler(IFileProcessService fileProcessService)
        {
            _fileProcessService = fileProcessService;
        }

        public async Task<ImageDeleteCommandResponse> Handle(ImageDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _fileProcessService.ImageDeleteAsync(request.Id);
            }
            else
            {
                return new()
                {                    
                    State = false,
                    Message = "Lütfen geçerli değerler giriniz."
                };
            }
        }
    }
}
