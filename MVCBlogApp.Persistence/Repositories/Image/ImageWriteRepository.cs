using MVCBlogApp.Application.Repositories.Image;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.Image
{
    public class ImageWriteRepository : WriteRepository<E.Image>, IImageWriteRepository
    {
        public ImageWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
