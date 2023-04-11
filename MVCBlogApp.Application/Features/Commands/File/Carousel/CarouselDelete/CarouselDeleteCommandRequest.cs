using MediatR;

namespace MVCBlogApp.Application.Features.Commands.File.Carousel.CarouselDelete
{
    public class CarouselDeleteCommandRequest : IRequest<CarouselDeleteCommandResponse>
    {
        public int Id { get; set; }
    }
}