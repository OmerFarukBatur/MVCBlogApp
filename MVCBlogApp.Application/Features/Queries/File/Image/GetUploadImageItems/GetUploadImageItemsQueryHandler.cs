using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.File.Image.GetUploadImageItems
{
    public class GetUploadImageItemsQueryHandler : IRequestHandler<GetUploadImageItemsQueryRequest, GetUploadImageItemsQueryResponse>
    {
        private readonly IFileProcessService _fileProcessService;

        public GetUploadImageItemsQueryHandler(IFileProcessService fileProcessService)
        {
            _fileProcessService = fileProcessService;
        }

        public async Task<GetUploadImageItemsQueryResponse> Handle(GetUploadImageItemsQueryRequest request, CancellationToken cancellationToken)
        {
            return await _fileProcessService.GetUploadImageItemsAsync();
        }
    }
}
