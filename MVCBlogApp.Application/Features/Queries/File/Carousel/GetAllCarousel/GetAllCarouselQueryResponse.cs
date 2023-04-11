using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.File.Carousel.GetAllCarousel
{
    public class GetAllCarouselQueryResponse
    {
        public List<VM_Carousel> Carousels { get; set; }
    }
}