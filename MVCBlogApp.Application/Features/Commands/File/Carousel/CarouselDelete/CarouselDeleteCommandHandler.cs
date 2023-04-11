
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.File.Carousel.CarouselDelete
{
    public class CarouselDeleteCommandHandler : IRequestHandler<CarouselDeleteCommandRequest, CarouselDeleteCommandResponse>
    {
        private readonly IFileProcessService _fileProcessService;

        public CarouselDeleteCommandHandler(IFileProcessService fileProcessService)
        {
            _fileProcessService = fileProcessService;
        }

        public async Task<CarouselDeleteCommandResponse> Handle(CarouselDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _fileProcessService.CarouselDeleteAsync(request.Id);
            }
            else
            {
                return new()
                {
                    State = false,
                    Message = "Kayıt bulunamamıştır."
                };
            }
        }
    }
}
