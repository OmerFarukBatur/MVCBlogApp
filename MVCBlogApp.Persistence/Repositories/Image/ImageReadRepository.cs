using MVCBlogApp.Application.Repositories.Image;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.Image
{
    public class ImageReadRepository : ReadRepository<E.Image>, IImageReadRepository
    {
        public ImageReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
