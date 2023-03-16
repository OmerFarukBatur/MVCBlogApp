using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.File.Video.GetVideoCreateItems
{
    public class GetVideoCreateItemsQueryHandler : IRequestHandler<GetVideoCreateItemsQueryRequest, GetVideoCreateItemsQueryResponse>
    {
        private readonly IFileProcessService _fileProcessService;

        public GetVideoCreateItemsQueryHandler(IFileProcessService fileProcessService)
        {
            _fileProcessService = fileProcessService;
        }

        public async Task<GetVideoCreateItemsQueryResponse> Handle(GetVideoCreateItemsQueryRequest request, CancellationToken cancellationToken)
        {
            return await _fileProcessService.GetVideoCreateItemsAsync();
        }
    }
}
