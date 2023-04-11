using MediatR;

namespace MVCBlogApp.Application.Features.Queries.File.Carousel.GetByIdCarousel
{
    public class GetByIdCarouselQueryRequest : IRequest<GetByIdCarouselQueryResponse>
    {
        public int Id { get; set; }
    }
}