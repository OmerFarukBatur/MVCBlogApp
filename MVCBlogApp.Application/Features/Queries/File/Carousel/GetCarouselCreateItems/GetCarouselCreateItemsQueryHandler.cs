using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.File.Carousel.GetCarouselCreateItems
{
    public class GetCarouselCreateItemsQueryHandler : IRequestHandler<GetCarouselCreateItemsQueryRequest, GetCarouselCreateItemsQueryResponse>
    {
        private readonly IFileProcessService _fileProcessService;

        public GetCarouselCreateItemsQueryHandler(IFileProcessService fileProcessService)
        {
            _fileProcessService = fileProcessService;
        }

        public async Task<GetCarouselCreateItemsQueryResponse> Handle(GetCarouselCreateItemsQueryRequest request, CancellationToken cancellationToken)
        {
            return await _fileProcessService.GetCarouselCreateItemsAsync();
        }
    }
}
