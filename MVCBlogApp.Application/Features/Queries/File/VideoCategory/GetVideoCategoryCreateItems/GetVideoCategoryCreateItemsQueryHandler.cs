using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.File.VideoCategory.GetVideoCategoryCreateItems
{
    public class GetVideoCategoryCreateItemsQueryHandler : IRequestHandler<GetVideoCategoryCreateItemsQueryRequest, GetVideoCategoryCreateItemsQueryResponse>
    {
        private readonly IFileProcessService _fileProcessService;

        public GetVideoCategoryCreateItemsQueryHandler(IFileProcessService fileProcessService)
        {
            _fileProcessService = fileProcessService;
        }

        public async Task<GetVideoCategoryCreateItemsQueryResponse> Handle(GetVideoCategoryCreateItemsQueryRequest request, CancellationToken cancellationToken)
        {
            return await _fileProcessService.GetVideoCategoryCreateItemsAsync();
        }
    }
}
