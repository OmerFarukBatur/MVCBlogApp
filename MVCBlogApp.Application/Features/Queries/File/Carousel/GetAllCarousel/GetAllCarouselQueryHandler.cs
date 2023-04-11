using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.File.Carousel.GetAllCarousel
{
    public class GetAllCarouselQueryHandler : IRequestHandler<GetAllCarouselQueryRequest, GetAllCarouselQueryResponse>
    {
        private readonly IFileProcessService _fileProcessService;

        public GetAllCarouselQueryHandler(IFileProcessService fileProcessService)
        {
            _fileProcessService = fileProcessService;
        }

        public async Task<GetAllCarouselQueryResponse> Handle(GetAllCarouselQueryRequest request, CancellationToken cancellationToken)
        {
            return await _fileProcessService.GetAllCarouselAsync();
        }
    }
}
