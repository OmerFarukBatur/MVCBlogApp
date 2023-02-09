using MVCBlogApp.Application.Repositories.Carousel;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.Carousel
{
    public class CarouselReadRepository : ReadRepository<E.Carousel>, ICarouselReadRepository
    {
        public CarouselReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
