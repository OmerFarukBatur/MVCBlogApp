using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.File.Banner.GetBannerCreateItems
{
    public class GetBannerCreateItemsQueryHandler : IRequestHandler<GetBannerCreateItemsQueryRequest, GetBannerCreateItemsQueryResponse>
    {
        private readonly IFileProcessService _fileProcessService;

        public GetBannerCreateItemsQueryHandler(IFileProcessService fileProcessService)
        {
            _fileProcessService = fileProcessService;
        }

        public async Task<GetBannerCreateItemsQueryResponse> Handle(GetBannerCreateItemsQueryRequest request, CancellationToken cancellationToken)
        {
            return await _fileProcessService.GetBannerCreateItemsAsync();
        }
    }
}
