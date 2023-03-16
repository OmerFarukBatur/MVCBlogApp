using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.File.Image.GetAllImage
{
    public class GetAllImageQueryHandler : IRequestHandler<GetAllImageQueryRequest, GetAllImageQueryResponse>
    {
        private readonly IFileProcessService _fileProcessService;

        public GetAllImageQueryHandler(IFileProcessService fileProcessService)
        {
            _fileProcessService = fileProcessService;
        }

        public async Task<GetAllImageQueryResponse> Handle(GetAllImageQueryRequest request, CancellationToken cancellationToken)
        {
            return await _fileProcessService.GetAllImageAsync();
        }
    }
}
