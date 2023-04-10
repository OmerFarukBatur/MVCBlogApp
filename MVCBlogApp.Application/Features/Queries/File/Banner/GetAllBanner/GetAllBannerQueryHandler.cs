using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.File.Banner.GetAllBanner
{
    public class GetAllBannerQueryHandler : IRequestHandler<GetAllBannerQueryRequest, GetAllBannerQueryResponse>
    {
        private readonly IFileProcessService _fileProcessService;

        public GetAllBannerQueryHandler(IFileProcessService fileProcessService)
        {
            _fileProcessService = fileProcessService;
        }

        public async Task<GetAllBannerQueryResponse> Handle(GetAllBannerQueryRequest request, CancellationToken cancellationToken)
        {
            return await _fileProcessService.GetAllBannerAsync();
        }
    }
}
