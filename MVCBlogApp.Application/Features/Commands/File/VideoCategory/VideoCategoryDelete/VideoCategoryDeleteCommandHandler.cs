using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.File.VideoCategory.VideoCategoryDelete
{
    public class VideoCategoryDeleteCommandHandler : IRequestHandler<VideoCategoryDeleteCommandRequest, VideoCategoryDeleteCommandResponse>
    {
        private readonly IFileProcessService _fileProcessService;

        public VideoCategoryDeleteCommandHandler(IFileProcessService fileProcessService)
        {
            _fileProcessService = fileProcessService;
        }

        public async Task<VideoCategoryDeleteCommandResponse> Handle(VideoCategoryDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _fileProcessService.VideoCategoryDeleteAsync(request.Id);
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
