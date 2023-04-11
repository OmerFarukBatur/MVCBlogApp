using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.File.Carousel.GetByIdCarousel
{
    public class GetByIdCarouselQueryResponse
    {
        public List<VM_Language>? Languages { get; set; }
        public List<AllStatus>? Statuses { get; set; }
        public VM_Carousel? Carousel { get; set; }
        public string? Message { get; set; }
        public bool State { get; set; }
    }
}