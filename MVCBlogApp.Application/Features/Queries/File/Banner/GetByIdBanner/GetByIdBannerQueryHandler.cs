using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.File.Banner.GetByIdBanner
{
    public class GetByIdBannerQueryHandler : IRequestHandler<GetByIdBannerQueryRequest, GetByIdBannerQueryResponse>
    {
        private readonly IFileProcessService _fileProcessService;

        public GetByIdBannerQueryHandler(IFileProcessService fileProcessService)
        {
            _fileProcessService = fileProcessService;
        }

        public async Task<GetByIdBannerQueryResponse> Handle(GetByIdBannerQueryRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _fileProcessService.GetByIdBannerAsync(request.Id);
            }
            else
            {
                return new()
                {
                    Banner = null,
                    Languages = null,
                    Statuses = null,
                    State = false,
                    Message = "Kayıt bulunamamıştır."
                };
            }
        }
    }
}
