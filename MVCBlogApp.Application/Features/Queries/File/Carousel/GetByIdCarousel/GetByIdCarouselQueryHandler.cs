using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.File.Carousel.GetByIdCarousel
{
    public class GetByIdCarouselQueryHandler : IRequestHandler<GetByIdCarouselQueryRequest, GetByIdCarouselQueryResponse>
    {
        private readonly IFileProcessService _fileProcessService;

        public GetByIdCarouselQueryHandler(IFileProcessService fileProcessService)
        {
            _fileProcessService = fileProcessService;
        }

        public async Task<GetByIdCarouselQueryResponse> Handle(GetByIdCarouselQueryRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _fileProcessService.GetByIdCarouselAsync(request.Id);
            }
            else
            {
                return new()
                {
                    Carousel = null,
                    Languages = null,
                    Statuses = null,
                    State = false,
                    Message = "Kayıt bulunamamıştır."
                };
            }
        }
    }
}
