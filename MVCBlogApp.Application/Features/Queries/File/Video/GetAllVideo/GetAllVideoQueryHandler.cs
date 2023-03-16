using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.File.Video.GetAllVideo
{
    public class GetAllVideoQueryHandler : IRequestHandler<GetAllVideoQueryRequest, GetAllVideoQueryResponse>
    {
        private readonly IFileProcessService _fileProcessService;

        public GetAllVideoQueryHandler(IFileProcessService fileProcessService)
        {
            _fileProcessService = fileProcessService;
        }

        public async Task<GetAllVideoQueryResponse> Handle(GetAllVideoQueryRequest request, CancellationToken cancellationToken)
        {
            return await _fileProcessService.GetAllVideoAsync();
        }
    }
}
