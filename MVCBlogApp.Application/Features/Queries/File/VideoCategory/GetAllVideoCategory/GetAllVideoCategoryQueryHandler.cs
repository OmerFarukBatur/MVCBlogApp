using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.File.VideoCategory.GetAllVideoCategory
{
    public class GetAllVideoCategoryQueryHandler : IRequestHandler<GetAllVideoCategoryQueryRequest, GetAllVideoCategoryQueryResponse>
    {
        private readonly IFileProcessService _fileProcessService;

        public GetAllVideoCategoryQueryHandler(IFileProcessService fileProcessService)
        {
            _fileProcessService = fileProcessService;
        }

        public async Task<GetAllVideoCategoryQueryResponse> Handle(GetAllVideoCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            return await _fileProcessService.GetAllVideoCategoryAsync();
        }
    }
}
